using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Domain.Parser;

public class ArrayVisitor : StellarisBaseVisitor<object[]>
{
    private readonly IVariableService variableService;

    public ArrayVisitor(IVariableService variableService)
    {
        this.variableService = variableService;
    }

    public override object[] VisitArray(StellarisParser.ArrayContext context) =>
        context.value().Select(vCTX =>
        {
            var visitor = new ValueVisitor(variableService);
            return visitor.VisitValue(vCTX);
        }).ToArray();
}