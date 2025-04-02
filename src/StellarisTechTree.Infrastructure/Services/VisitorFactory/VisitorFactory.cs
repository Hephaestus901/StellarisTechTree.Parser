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

    public FileMapVisitor GetFileMapVisitor() => new(_variableService);
}