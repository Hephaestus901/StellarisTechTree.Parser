using StellarisTechTree.Application.Services;
using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Parsers;

public class PairVisitor : StellarisBaseVisitor<KeyValuePair<string, object>>
{
    private readonly IVariableService _variableService;

    public PairVisitor(IVariableService variableService)
    {
        _variableService = variableService;
    }

    public override KeyValuePair<string, object> VisitPair(StellarisParser.PairContext context)
    {
        var name = context.BAREWORD().GetText();
        var rawValue = new ValueVisitor(_variableService).VisitValue(context.value());

        return new KeyValuePair<string, object>(name, rawValue);
    }
}