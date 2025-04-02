using StellarisTechTree.Infrastructure.Parsers;

namespace StellarisTechTree.Infrastructure.Services.VisitorFactory;

public interface IVisitorFactory
{
    FileMapVisitor GetFileMapVisitor();
}