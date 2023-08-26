using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Infrastructure.Parsers;
using StellarisTechTree.Infrastructure.Services.ContextService;

namespace StellarisTechTree.Infrastructure.Services;

public class VariableService : IVariableService
{
    private const string VariablesSection = "Variables";
    private const string TechnologiesSection = "Technologies";
    private readonly IFileService _fileService;
    private readonly IContextService _contextService;
    private Dictionary<string, decimal> _variables;

    private Dictionary<string, decimal> Variables => _variables;

    public VariableService(IFileService fileService, IContextService contextService)
    {
        _fileService = fileService;
        _contextService = contextService;
        _variables = GetVariables();
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
        var fileMapVisitor = new FileMapVisitor(this, onlyVariables: true);
        var files = _fileService.GetFiles(VariablesSection).ToList();
        files.AddRange(_fileService.GetFiles(TechnologiesSection));
        var result = new Dictionary<string, decimal>();
        result = files.Select(_contextService.GetFileContext)
             .Select(fileMapVisitor.VisitFile)
             .Where(x => x.Any())
             .Select(x => x.ToDictionary(kp => kp.Key, kp => kp.Value.ToDecimal()))
             .Aggregate(new Dictionary<string, decimal>(), (acc, value) => acc.ConcatDict(value));
        return result;
    }
}