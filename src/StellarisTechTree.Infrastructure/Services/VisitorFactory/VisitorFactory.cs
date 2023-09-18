using StellarisTechTree.Application.Services;
using StellarisTechTree.Infrastructure.Parsers;

namespace StellarisTechTree.Infrastructure.Services.VisitorFactory;

public class VisitorFactory : IVisitorFactory
{
    private readonly IVariableService _variableService;

    public VisitorFactory(IVariableService variableService)
    {
        _variableService = variableService;
    }

    public ArrayVisitor GetArrayVisitor() => new(_variableService);

    public FileMapVisitor GetFileMapVisitor() => new(_variableService);
    public FileMapVisitor GetVariableVisitor() => new(_variableService, true);

    public ValueVisitor GetValueVisitor() => new(_variableService);

    public PairVisitor GetPairVisitor() => new(_variableService);
}