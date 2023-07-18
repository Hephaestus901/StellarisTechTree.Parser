using Microsoft.AspNetCore.Mvc;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Domain.Relations;
using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> logger;
    private readonly IVisitorFactory visitorFactory;
    private readonly IFileService fileService;

    public DataController(ILogger<DataController> logger, IVisitorFactory visitorFactory, IFileService fileService)
    {
        this.logger = logger;
        this.visitorFactory = visitorFactory;
        this.fileService = fileService;
    }

    [HttpGet]
    [Route("tech")]
    public IActionResult Tech()
    {
        var visitor = visitorFactory.GetFileMapVisitor();
        var files = fileService.GetFiles("Technologies");
        var result = files.Select(fileService.GetFileContext)
                          .Select(visitor.VisitFile)
                          .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));

        return this.Ok(result);
    }

    [HttpGet]
    [Route("relations")]
    public IActionResult Connections()
    {
        var visitor = visitorFactory.GetFileMapVisitor();
        var files = fileService.GetFiles("Technologies");
        var result = files.Select(fileService.GetFileContext)
                          .Select(visitor.VisitFile)
                          .Aggregate(new Dictionary<string, object>(), (result, value) => result.ConcatDict(value));
        // TODO: Extract
        var nodes = result.Select(x =>
        {
            var dictValue = (Dictionary<string, object>)x.Value;
            var isStarting = dictValue.TryGetValue("start_tech", out var value) && (bool)value;
            return new RelationNode(x.Key, isStarting);
        }).ToList();
        foreach (var x in result)
        {
            var existingNode = nodes.First(n => n.Name == x.Key);
            var dictValue = (Dictionary<string, object>)x.Value;
            if (!dictValue.ContainsKey("prerequisites") || dictValue["prerequisites"] is not object[])
            {
                continue;
            }

            var rawValue = (object[])dictValue["prerequisites"];
            foreach (var s in rawValue)
            {
                var childNode = nodes.FirstOrDefault(n => n.Name == s.ToString());
                childNode?.AddChild(existingNode);
            }
        }

        return this.Ok(nodes.Where(x => x.IsStartingNode).ToList());
    }
}