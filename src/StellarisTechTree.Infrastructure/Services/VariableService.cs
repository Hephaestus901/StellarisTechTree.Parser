using System.Text.RegularExpressions;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Functional;
using StellarisTechTree.Infrastructure.Services.ContextService;

namespace StellarisTechTree.Infrastructure.Services;

public class VariableService : IVariableService
{
    private static readonly Regex VariableRegex = new(@"@.+\=.+\n");

    private static readonly Regex CommentRegex = new("#.+");

    private const string VariablesSection = "Variables";
    private const string TechnologiesSection = "Technologies";
    private readonly IFileService _fileService;
    private readonly IContextService _contextService;

    private Dictionary<string, decimal> Variables { get; }

    public VariableService(IFileService fileService, IContextService contextService)
    {
        _fileService = fileService;
        _contextService = contextService;
        Variables = GetVariables();
    }

    public decimal GetVariableValue(string variable)
    {
        if (Variables.TryGetValue(variable, out var value))
        {
            return value;
        }

        throw new ArgumentException("Key was is not a variable", variable);
    }

    private Dictionary<string, decimal> GetVariables()
    {
        return Enumerable.Empty<string>()
            .Concat(_fileService.GetFiles(VariablesSection))
            .Concat(_fileService.GetFiles(TechnologiesSection))
            .Select(_contextService.GetFileContent)
            .Select(x =>
            {
                var text = CommentRegex.Replace(x, string.Empty);
                var matches = VariableRegex.Matches(text);
                return string.Join(string.Empty, matches.Select(m => m.Value));
            })
            .Select(VariableParser.getParsingResult)
            .Where(x => x.IsOk)
            .Select(x => x.ResultValue.ToDictionary(kp => kp.Item1, kp => Convert.ToDecimal(kp.Item2)))
            .Aggregate(new Dictionary<string, decimal>(), (acc, value) => acc.ConcatDict(value));
    }
}