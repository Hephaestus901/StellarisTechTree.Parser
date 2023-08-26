using Microsoft.AspNetCore.Mvc;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Infrastructure.Parsers;
using StellarisTechTree.Infrastructure.Services.ContextService;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LocaleController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IContextService _contextService;

    public LocaleController(IFileService fileService, IContextService contextService)
    {
        _fileService = fileService;
        _contextService = contextService;
    }

    [HttpGet("{language}")]
    public Dictionary<string, string> Get(string language)
    {
        var visitor = new LocaleVisitor(LocaleTopic.Names);
        var files = _fileService.GetFiles($"Locales:{language}");

        var localeValues = files.Select(_contextService.GetLocaleFileContext)
                                .Select(visitor.VisitLocaleFile)
                                .SelectMany(x => x)
                                .ToDictionary(pair => pair.Key, pair => pair.Value);

        var result = localeValues
                     .Where(x => x.Key.StartsWith("tech_", StringComparison.InvariantCultureIgnoreCase))
                     .ToDictionary(pair => pair.Key, pair => pair.Value);
        var haveChanges = true;
        
        while (result.Any(x => x.Value.StartsWith("$", StringComparison.InvariantCultureIgnoreCase)) && haveChanges)
        {
            haveChanges = false;
            foreach (var pair in result)
            {
                if (!pair.Value.StartsWith('$') ||
                    !localeValues.TryGetValue(pair.Value.Trim('$'), out var fixedValue))
                {
                    continue;
                }
                result[pair.Key] = fixedValue;
                haveChanges = true;
            }
        }
        
        return result;
    }

    [HttpGet("{language}")]
    public Dictionary<string, string> GetDescription(string language)
    {
        var visitor = new LocaleVisitor(LocaleTopic.Descriptions);
        var files = _fileService.GetFiles($"Locales:{language}");
        var localeValues = files.Select(_contextService.GetLocaleFileContext)
                                .Select(visitor.VisitLocaleFile)
                                .SelectMany(x => x)
                                .ToDictionary(pair => pair.Key, pair => pair.Value);

        var result = localeValues
                     .Where(x => x.Key.StartsWith("tech_", StringComparison.InvariantCultureIgnoreCase))
                     .ToDictionary(pair => pair.Key, pair => pair.Value);
        var haveChanges = true;
        
        while (result.Any(x => x.Value.StartsWith("$", StringComparison.InvariantCultureIgnoreCase)) && haveChanges)
        {
            haveChanges = false;
            foreach (var pair in result)
            {
                if (!pair.Value.StartsWith('$') ||
                    !localeValues.TryGetValue(pair.Value.Trim('$'), out var fixedValue))
                {
                    continue;
                }
                result[pair.Key] = fixedValue;
                haveChanges = true;
            }
        }

        return result;
    }
}