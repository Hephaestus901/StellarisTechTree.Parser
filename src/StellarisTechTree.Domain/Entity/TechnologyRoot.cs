using System.Text.Json.Serialization;

namespace StellarisTechTree.Domain.Entity;

public class TechnologyRoot
{
    [JsonPropertyName("Tech")]
    public List<Technology> Tech { get; private set; }

    private List<Technology> RawTech { get; set; }

    public TechnologyRoot(IEnumerable<Technology> technologies)
    {
        Tech = new List<Technology>();
        RawTech = new List<Technology>(technologies);
        BuildHierarchy();
    }

    private void BuildHierarchy()
    {
        foreach (var rawTech in RawTech)
        {
            var parent = GetClosestParent(rawTech,
                rawTech.Prerequisites.Select(GetTech).Where(x => x != null).ToList()!);
            parent?.AddChild(rawTech);

            if (rawTech.IsStartTech || !rawTech.Prerequisites.Any())
            {
                Tech.Add(rawTech);
            }
        }

        Tech = Tech.OrderBy(x => x.Area).ToList();
    }

    private Technology? GetTech(string name)
    {
        return RawTech.SingleOrDefault(x => x.Name == name);
    }

    private Technology? GetClosestParent(Technology child, List<Technology> potentialParents)
    {
        if (potentialParents.Count < 2)
        {
            return potentialParents.FirstOrDefault();
        }

        var nameTemplate = child.Name[..child.Name.LastIndexOf("_", StringComparison.Ordinal)];
        return potentialParents.FirstOrDefault(x => x.Name.Contains(nameTemplate));
    }
}