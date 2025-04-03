using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using StellarisTechTree.Application;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Functional;
using StellarisTechTree.Infrastructure.Services.ContextService;

namespace StellarisTechTree.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public partial class LocaleController(
    IFileService fileService,
    IContextService contextService,
    IMappingService mappingService)
    : ControllerBase
{
    [GeneratedRegex(@"^ethic_(fanatic_)?[A-Za-z]+\b")]
    private static partial Regex EthicRegex();
    
    /*
     * TODO: добавить фильтрацию для дескрипшнов
     * * если нужны дескрипшны - EndsWith("desc") || EndsWith("details")
     * * если все кроме - !EndsWith("desc") && !EndsWith("details")
     */
    [HttpGet]
    [Route("{language}")]
    public Dictionary<string, string> GetFunctional(LocaleLanguage language) =>
        fileService
            .GetFiles($"Locales:{language.GetDisplayName()}")
            .AsParallel()
            .Select(contextService.GetFileContent)
            .Select(LocaleParser.getParsingResult)
            .Where(x => x.IsOk)
            .Select(x => mappingService.MapToObject(x.ResultValue))
            .SelectMany(x => x)
            .Where(x =>
                x.Key.StartsWith("tech_", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.StartsWith("ap_", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.StartsWith("leader_trait_", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.StartsWith("starbase_", StringComparison.InvariantCulture) ||
                (x.Key.StartsWith("origin_") && !x.Key.Contains("effect") && !x.Key.Contains('.')) ||
                x.Key.StartsWith("pc_") ||
                x.Key.Equals("robots_outlawed_name", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.Equals("ai_outlawed", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.Equals("specialist_bulwark", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.Equals("specialist_scholarium", StringComparison.InvariantCultureIgnoreCase) ||
                x.Key.Equals("specialist_prospectorium", StringComparison.InvariantCultureIgnoreCase) ||
                EthicRegex().IsMatch(x.Key) ||
                x.Key.StartsWith("tr_", StringComparison.InvariantCultureIgnoreCase))
            .ToDictionary();
}