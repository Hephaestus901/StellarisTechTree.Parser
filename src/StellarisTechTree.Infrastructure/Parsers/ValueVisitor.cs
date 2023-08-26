using StellarisTechTree.Application.Services;
using StellarisTechTree.Domain.Extensions;
using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Parsers;

public class ValueVisitor : StellarisBaseVisitor<object>
{
    private readonly IVariableService _variableService;

    public ValueVisitor(IVariableService variableService)
    {
        _variableService = variableService;
    }
    
    public override object VisitValue(StellarisParser.ValueContext context)
    {
        if (context.IsEmpty)
        {
            return string.Empty;
        }

        if (context.map() != null)
        {
            var mapVisitor = new FileMapVisitor(_variableService);
            return mapVisitor.VisitMap(context.map());
        }

        if (context.array() != null)
        {
            var arrayVisitor = new ArrayVisitor(_variableService);
            return arrayVisitor.VisitArray(context.array());
        }

        if (context.BOOLEAN() != null)
        {
            switch (context.BOOLEAN().GetText())
            {
                case"yes":
                case"true":
                    return true;
                case"false":
                case"no":
                    return false;
                default:
                    throw new Exception("Unsupported boolean format");
            }
        }

        if (context.NUMBER() != null)
        {
            return context.NUMBER().GetText().ToDecimal();
        }

        if (context.VARIABLE() != null)
        {
            return _variableService.GetVariableValue(context.VARIABLE().GetText());
        }

        return context.GetText().Replace("\"", "");
    }
}