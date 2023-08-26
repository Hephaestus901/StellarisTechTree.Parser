using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Parsers;

public class FileMapVisitor : StellarisBaseVisitor<Dictionary<string, object>>
{
    private readonly IVariableService _variableService;
    private readonly bool _onlyVariables;

    public FileMapVisitor(IVariableService variableService, bool onlyVariables = false)
    {
        _variableService = variableService;
        _onlyVariables = onlyVariables;
    }

    public override Dictionary<string, object> VisitFile(StellarisParser.FileContext context)
    {
        if (_onlyVariables)
        {
            return context.var().Length != 0 ? TraverseVarFile(context.var()) : new Dictionary<string, object>();
        }

        return context.pair().Length != 0
            ? TraverseMapStructure(context.pair())
            : TraverseVarFile(context.var());
    }

    public override Dictionary<string, object> VisitMap(StellarisParser.MapContext context) =>
        TraverseMapStructure(context.pair());

    private Dictionary<string, object> TraverseMapStructure(IEnumerable<StellarisParser.PairContext> pairs) =>
        pairs.Select(pCtx =>
             {
                 var visitor = new PairVisitor(_variableService);
                 return visitor.VisitPair(pCtx);
             })
             .GroupBy(x => x.Key)
             .Select(group =>
                 group.Count() == 1
                     ? group.First()
                     : new KeyValuePair<string, object>(group.Key, group.Select(x => x.Value).ToArray()))
             .ToDictionary(pCtx => pCtx.Key, pCtx => pCtx.Value);

    private Dictionary<string, object> TraverseVarFile(StellarisParser.VarContext[] variables) =>
        variables.Select(v =>
        {
            return new KeyValuePair<string, decimal>(v.VARIABLE().GetText(), v.NUMBER().GetText().ToDecimal());
        }).ToDictionary(pCtx => pCtx.Key, pCtx => (object)pCtx.Value);
}