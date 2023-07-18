namespace StellarisTechTree.Domain.Relations;

public class RelationNode
{
    public string Name { get; }
    public bool IsStartingNode { get; }
    public HashSet<RelationNode> Children { get; }

    public RelationNode(string name, bool isStartingNode)
    {
        Name = name;
        IsStartingNode = isStartingNode;
        Children = new HashSet<RelationNode>();
    }

    public void AddChild(RelationNode node)
    {
        Children.Add(node);
    }

    public override int GetHashCode() => Name.GetHashCode();
}