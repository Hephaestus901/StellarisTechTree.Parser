using StellarisTechTree.Application.Services;
using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Parsers;

public class ArrayVisitor : StellarisBaseVisitor<object[]>
{
    private readonly IVariableService _variableService;

    public ArrayVisitor(IVariableService variableService)
    {
        _variableService = variableService;
    }

    public override object[] VisitArray(StellarisParser.ArrayContext context) =>
        context.value().Select(vCTX =>
        {
            var visitor = new ValueVisitor(_variableService);
            return visitor.VisitValue(vCTX);
        }).ToArray();
}