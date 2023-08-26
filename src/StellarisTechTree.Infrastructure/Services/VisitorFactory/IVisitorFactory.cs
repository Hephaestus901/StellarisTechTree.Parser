using StellarisTechTree.Infrastructure.Parsers;

namespace StellarisTechTree.Infrastructure.Services.VisitorFactory;

public interface IVisitorFactory
{
    ArrayVisitor GetArrayVisitor();
    FileMapVisitor GetFileMapVisitor();
    FileMapVisitor GetVariableVisitor();
    ValueVisitor GetValueVisitor();
    PairVisitor GetPairVisitor();
}