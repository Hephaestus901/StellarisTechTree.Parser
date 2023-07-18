using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Domain.Parser;
using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Application.Services;

public class VariableService : IVariableService
{
    private const string VariablesSection = "Variables";
    private readonly IFileService fileService;
    private Dictionary<string, decimal> variables;
    
    private Dictionary<string, decimal> Variables => variables.Any() ? variables : GetVariables();

    public VariableService(IFileService fileService)
    {
        this.fileService = fileService;
        variables = new Dictionary<string, decimal>();
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
        var fileMapVisitor = new FileMapVisitor(this);
        var files = fileService.GetFiles(VariablesSection);
        variables = files.Select(fileService.GetFileContext)
             .Select(fileMapVisitor.VisitFile)
             .Select(x => x.ToDictionary(kp => kp.Key, kp => kp.Value.ToDecimal()))
             .Aggregate(new Dictionary<string, decimal>(), (acc, value) => acc.ConcatDict(value));
        return variables;
    }
}