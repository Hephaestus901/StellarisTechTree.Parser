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
        var namedParent = potentialParents.FirstOrDefault(x => x.Name.Contains(nameTemplate));
        if (namedParent != null)
        {
            return namedParent;
        }

        var sameArea = potentialParents.Where(x => x.Area == child.Area).ToArray();
        if (sameArea.Length == 1)
        {
            return sameArea[0];
        }

        var sameGateway = sameArea.Where(x => x.Gateway == child.Gateway).ToArray();
        if (sameGateway.Length == 1)
        {
            return sameGateway[0];
        }

        var sameRarity = sameGateway.Where(x => x.IsRare == child.IsRare).ToArray();
        if (sameRarity.Length == 1)
        {
            return sameRarity[0];
        }

        return potentialParents.First();
    }
}