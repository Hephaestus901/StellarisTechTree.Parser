using StellarisTechTree.Domain.Parser;
using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Application.Services;

public class VisitorFactory : IVisitorFactory
{
    private readonly IVariableService variableService;

    public VisitorFactory(IVariableService variableService)
    {
        this.variableService = variableService;
    }

    public ArrayVisitor GetArrayVisitor() => new(variableService);

    public FileMapVisitor GetFileMapVisitor() => new(variableService);

    public ValueVisitor GetValueVisitor() => new(variableService);

    public PairVisitor GetPairVisitor() => new(variableService);
}