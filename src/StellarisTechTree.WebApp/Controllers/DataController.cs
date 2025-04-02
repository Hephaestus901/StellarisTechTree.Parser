using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using StellarisTechTree.Application;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Entity;
using StellarisTechTree.Functional;
using StellarisTechTree.Infrastructure.Services.ContextService;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataController(
    IFileService fileService,
    IContextService contextService,
    IMappingService mappingService)
    : ControllerBase
{
    private IEnumerable<Technology> GetTechnologies() =>
        fileService.GetFiles("Technologies").Select(contextService.GetFileContent)
            .Select(TechParser.getParsingResult)
            .Select(x =>
            {
                if (x.IsError)
                {
                    throw new Exception(x.ErrorValue);
                }

                return x;
            })
            .SelectMany(x => x.ResultValue)
            .Cast<Types.Property.ObjectProperty>()
            .Select(mappingService.MapToObject)
            .Select(x => new Technology(x));

    [HttpGet]
    public IEnumerable<Technology> GetFunctional() =>
        new TechnologyRoot(GetTechnologies()).Tech;

    [HttpGet]
    public IEnumerable<Technology> GetFunctionalByArea(Area area) =>
        new TechnologyRoot(
                GetTechnologies()
                    .Where(x => string.Equals(x.Area, area.GetDisplayName(),
                        StringComparison.InvariantCultureIgnoreCase)))
            .Tech;
}