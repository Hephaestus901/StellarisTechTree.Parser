using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
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
        _visitorFactory = visitorFactory;
        _fileService = fileService;
        _contextService = contextService;
    }

    [HttpGet]
    public IEnumerable<Technology> Get()
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

        return technologyRoot.Tech;
    }

    [HttpGet("{area}")]
    public IEnumerable<Technology> ByArea(Area area)
    {
        var visitor = _visitorFactory.GetFileMapVisitor();
        var files = _fileService.GetFiles("Technologies");
        var result = files.Select(_contextService.GetFileContext)
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