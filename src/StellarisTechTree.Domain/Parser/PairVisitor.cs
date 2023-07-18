using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Domain.Parser;

public class PairVisitor : StellarisBaseVisitor<KeyValuePair<string, object>>
{
    private readonly IVariableService variableService;

    public PairVisitor(IVariableService variableService)
    {
        this.variableService = variableService;
    }

    public override KeyValuePair<string, object> VisitPair(StellarisParser.PairContext context)
    {
        var name = context.BAREWORD().GetText();
        var rawValue = new ValueVisitor(variableService).VisitValue(context.value());

        return new KeyValuePair<string, object>(name, rawValue);
    }
}