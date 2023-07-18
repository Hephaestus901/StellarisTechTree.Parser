using StellarisTechTree.Domain.Parser;

namespace StellarisTechTree.Domain.Services;

public interface IVisitorFactory
{
    ArrayVisitor GetArrayVisitor();
    FileMapVisitor GetFileMapVisitor();
    ValueVisitor GetValueVisitor();
    PairVisitor GetPairVisitor();
}