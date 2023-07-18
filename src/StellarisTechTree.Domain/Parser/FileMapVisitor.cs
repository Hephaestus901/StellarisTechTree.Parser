using System.Globalization;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Domain.Parser;

public class FileMapVisitor : StellarisBaseVisitor<Dictionary<string, object>>
{
    private readonly IVariableService variableService;

    public FileMapVisitor(IVariableService variableService)
    {
        this.variableService = variableService;
    }

    public override Dictionary<string, object> VisitFile(StellarisParser.FileContext context) =>
        context.var().Length != 0 
            ? TraverseVarFile(context.var())
            : TraverseMapStructure(context.pair());

    public override Dictionary<string, object> VisitMap(StellarisParser.MapContext context) =>
        TraverseMapStructure(context.pair());

    private Dictionary<string, object> TraverseMapStructure(IEnumerable<StellarisParser.PairContext> pairs) =>
        pairs.Select(pCtx =>
             {
                 var visitor = new PairVisitor(variableService);
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