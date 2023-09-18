using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace StellarisTechTree.Domain.Entity;

public class Technology
{
    /// <summary>
    /// society|engineering|physics
    /// </summary>
    public string Area { get; init; } = string.Empty;

    public string Name { get; init; }

    public decimal Cost { get; init; }

    [JsonPropertyName("start_tech")]
    public bool IsStartTech { get; init; }

    [JsonPropertyName("is_rare")]
    public bool IsRare { get; init; }

    public decimal Tier { get; init; }

    public decimal Weight { get; init; }

    public string Gateway { get; init; } = string.Empty;
    
    [JsonPropertyName("is_event")]
    public bool IsEvent { get; init; }
    
    [JsonPropertyName("is_dangerous")]
    public bool IsDangerous { get; init; }

    public ReadOnlyCollection<string> Category { get; init; } = new(Array.Empty<string>());

    public ReadOnlyCollection<string> Prerequisites { get; init; } = new(Array.Empty<string>());

    [JsonPropertyName("weight_modifier")]
    public Dictionary<string, object> WeightModifier { get; init; } = new();

    public Dictionary<string, object> Modifier { get; init; } = new();

    public ReadOnlyCollection<Technology> Children { get; private set; }

    public Technology(KeyValuePair<string, object> techPayload)
    {
        Name = techPayload.Key;
        Children = new ReadOnlyCollection<Technology>(Array.Empty<Technology>());
        if (techPayload.Value is not Dictionary<string, object> payloadValue)
        {
            return;
        }

        Area = payloadValue.TryGetValue("area", out var rawArea) && rawArea is string area ? area : string.Empty;
        Gateway = payloadValue.TryGetValue("gateway", out var rawGateway) && rawGateway is string gateway
            ? gateway
            : string.Empty;

        IsStartTech = payloadValue.TryGetValue("start_tech", out var rawStartTech) && rawStartTech is true;
        IsRare = payloadValue.TryGetValue("is_rare", out var rawIsRare) && rawIsRare is true;
        IsDangerous = payloadValue.TryGetValue("is_dangerous", out var rawIsDangerous) && rawIsDangerous is true;

        Cost = payloadValue.TryGetValue("cost", out var rawCost) && rawCost is decimal cost ? cost : default;
        Tier = payloadValue.TryGetValue("tier", out var rawTier) && rawTier is decimal tier ? tier : default;
        Weight = payloadValue.TryGetValue("weight", out var rawWeight) && rawWeight is decimal weight
            ? weight
            : default;

        Prerequisites = payloadValue.TryGetValue("prerequisites", out var rawPrereqs) && rawPrereqs is object[] prereqs
            ? new ReadOnlyCollection<string>(prereqs.Select(x => x.ToString()!).ToArray())
            : new ReadOnlyCollection<string>(Array.Empty<string>());
        Category = payloadValue.TryGetValue("category", out var rawCategory) && rawCategory is object[] category
            ? new ReadOnlyCollection<string>(category.Select(x => x.ToString()!).ToArray())
            : new ReadOnlyCollection<string>(Array.Empty<string>());
        WeightModifier =
            payloadValue.TryGetValue("weight_modifier", out var rawWeightModifier) &&
            rawWeightModifier is Dictionary<string, object> weightModifier
                ? weightModifier
                : new Dictionary<string, object>();
        Modifier =
            payloadValue.TryGetValue("modifier", out var rawModifier) &&
            rawModifier is Dictionary<string, object> modifier
                ? modifier
                : new Dictionary<string, object>();

        IsEvent = Prerequisites.Count == 0 && !IsStartTech && Weight == 0;
    }

    public void AddChild(Technology technology)
    {
        var technologyFromSameArea = technology.Area == Area;
        var technologyWasNotAlreadyAdded = Children.All(x => x.Name != technology.Name);
        var technologyIsNotStartingTech = !technology.IsStartTech;
        if (technologyFromSameArea && technologyWasNotAlreadyAdded && technologyIsNotStartingTech)
        {
            Children = new ReadOnlyCollection<Technology>(Children.Concat(new[] { technology }).ToArray());
        }
    }
}