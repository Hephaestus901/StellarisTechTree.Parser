using Microsoft.AspNetCore.Mvc;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Entity;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Infrastructure.Services.ContextService;
using StellarisTechTree.Infrastructure.Services.VisitorFactory;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DataController : ControllerBase
{
    private readonly IVisitorFactory _visitorFactory;
    private readonly IFileService _fileService;
    private readonly IContextService _contextService;

    public DataController(IVisitorFactory visitorFactory, IFileService fileService, IContextService contextService)
    {
        this._visitorFactory = visitorFactory;
        this._fileService = fileService;
        _contextService = contextService;
    }

    [HttpGet]
    public TechnologyRoot Get()
    {
        var visitor = _visitorFactory.GetFileMapVisitor();
        var files = _fileService.GetFiles("Technologies");
        var result = files.Select(_contextService.GetFileContext)
                          .Select(visitor.VisitFile)
                          .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));
        
        var typedResult = result.Where(x => x.Value is Dictionary<string, object>)
                                .Select(x => new Technology(x))
                                .ToList();

        var technologyRoot = new TechnologyRoot(typedResult);

        return technologyRoot;
    }

    [HttpGet("{area}")]
    public TechnologyRoot ByArea(string area)
    {
        var visitor = _visitorFactory.GetFileMapVisitor();
        var files = _fileService.GetFiles("Technologies");
        var result = files.Select(_contextService.GetFileContext)
                          .Select(visitor.VisitFile)
                          .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));
        
        var typedResult = result.Where(x => x.Value is Dictionary<string, object>)
                                .Select(x => new Technology(x))
                                .Where(x => x.Area == area)
                                .ToList();

        var technologyRoot = new TechnologyRoot(typedResult);

        return technologyRoot;
    }
}