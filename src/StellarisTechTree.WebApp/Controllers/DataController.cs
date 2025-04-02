using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using StellarisTechTree.Application;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Entity;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Functional;
using StellarisTechTree.Infrastructure.Services.ContextService;
using StellarisTechTree.Infrastructure.Services.VisitorFactory;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataController(
    IVisitorFactory visitorFactory,
    IFileService fileService,
    IContextService contextService,
    IMappingService mappingService)
    : ControllerBase
{
    private IEnumerable<Technology> GetTechnologies()
    {
        var resultFiles = fileService.GetFiles("Technologies")
            .ToList();

        var result = resultFiles.Select(contextService.GetFileContent)
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
            .Select(x => new Technology(x))
            .ToList();

        return result;
    }

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

    [HttpGet]
    public IEnumerable<Technology> Get()
    {
        var visitor = visitorFactory.GetFileMapVisitor();
        var files = fileService.GetFiles("Technologies");
        var result = files.Select(contextService.GetFileContext)
            .Select(visitor.VisitFile)
            .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));

        var typedResult = result.Where(x => x.Value is Dictionary<string, object>)
            .Select(x => new Technology(x))
            .ToList();

        var technologyRoot = new TechnologyRoot(typedResult);

        return technologyRoot.Tech;
    }

    [HttpGet("{area}")]
    public IEnumerable<Technology> ByArea(Area area)
    {
        var visitor = visitorFactory.GetFileMapVisitor();
        var files = fileService.GetFiles("Technologies");
        var result = files.Select(contextService.GetFileContext)
            .Select(visitor.VisitFile)
            .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));

        var typedResult = result.Where(x => x.Value is Dictionary<string, object>)
            .Select(x => new Technology(x))
            .Where(x => string.Equals(x.Area, area.GetDisplayName(), StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        var technologyRoot = new TechnologyRoot(typedResult);

        return technologyRoot.Tech;
    }
}