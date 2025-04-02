using Microsoft.FSharp.Collections;
using StellarisTechTree.Application;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Functional;

namespace StellarisTechTree.Infrastructure.Mapping;

public class MappingService(IVariableService variableService) : IMappingService
{
    private readonly IVariableService _variableService = variableService;
    
    public KeyValuePair<string, object> MapToObject(Types.Property parsedContent) =>
        MapProperty(parsedContent);

    public Dictionary<string, string> MapToObject(FSharpList<Types.LocaleObject> parsedContent) =>
        parsedContent.Select(MapProperty).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    private KeyValuePair<string, object> MapProperty(Types.Property property)
    {
        if (property.IsObjectProperty)
            return MapObjectProperty((property as Types.Property.ObjectProperty)!);

        if (property.IsArrayProperty)
            return MapArrayProperty((property as Types.Property.ArrayProperty)!);

        return MapSingleProperty((property as Types.Property.SingleProperty)!);
    }

    private KeyValuePair<string, string> MapProperty(Types.LocaleObject property) =>
        new(property.Item1, property.Item2.Item);

    private KeyValuePair<string, object> MapObjectProperty(Types.Property.ObjectProperty objectProperty)
    {
        var name = objectProperty.Item1;
        var value = new Dictionary<string, object>();
        foreach (var valueItem in objectProperty.Item2.Select(MapProperty))
        {
            if (!value.TryGetValue(valueItem.Key, out var existingValue))
            {
                value.Add(valueItem.Key, valueItem.Value);
                continue;
            }

            if (existingValue is List<object> existingList)
            {
                value[valueItem.Key] = existingList.Append(valueItem.Value).ToList();
                continue;
            }
            
            value[valueItem.Key] = new List<object> { existingValue, valueItem.Value };
        }

        return new KeyValuePair<string, object>(name, value);
    }

    private KeyValuePair<string, object> MapSingleProperty(Types.Property.SingleProperty singleProperty)
    {
        var name = GetNameFromIdentifier(singleProperty.Item1);
        if (singleProperty.Item1.IsComparatorIdentifier)
        {
            return new KeyValuePair<string, object>(name, new
            {
                Relation = GetSignFromIdentifier((singleProperty.Item1 as Types.Identifier.ComparatorIdentifier)!.Item.Item2),
                Value = GetValueFromTypeValue(singleProperty.Item2)
            });
        }

        return new KeyValuePair<string, object>(name, GetValueFromTypeValue(singleProperty.Item2));
    }

    private KeyValuePair<string, object> MapArrayProperty(Types.Property.ArrayProperty arrayProperty) =>
        new(arrayProperty.Item1,
            arrayProperty.Item2.Select(GetValueFromTypeValue).ToArray());

    private static string GetNameFromIdentifier(Types.Identifier identifier) =>
        identifier.IsNameIdentifier
            ? (identifier as Types.Identifier.NameIdentifier)!.Item
            : (identifier as Types.Identifier.ComparatorIdentifier)!.Item.Item1;

    private static string GetSignFromIdentifier(Types.Condition condition) =>
        condition switch
        {
            { IsGreaterThan: true } => "GreaterThan",
            { IsLesserThan: true } => "LesserThan",
            { IsGreaterThanOrEqualsTo: true } => "GreaterThanOrEqualsTo",
            { IsLesserThenOrEqualsTo: true } => "LesserThenOrEqualsTo",
            _ => "Unknown"
        };

    private object GetValueFromTypeValue(Types.TypeValue typeValue)
    {
        if (typeValue.IsBooleanValue)
            return GetBooleanValue((typeValue as Types.TypeValue.BooleanValue)!);

        if (typeValue.IsFloatValue)
            return GetDoubleValue((typeValue as Types.TypeValue.FloatValue)!);

        if (typeValue.IsVariable)
            return GetVariableValue((typeValue as Types.TypeValue.Variable)!);

        if (typeValue.IsIntValue)
            return GetIntValue((typeValue as Types.TypeValue.IntValue)!);

        return GetStringValue((typeValue as Types.TypeValue.StringValue)!);
    }

    private static int GetIntValue(Types.TypeValue.IntValue intValue) => intValue.Item;

    private static bool GetBooleanValue(Types.TypeValue.BooleanValue booleanValue) => booleanValue.Item;

    private static double GetDoubleValue(Types.TypeValue.FloatValue floatValue) => floatValue.Item;

    private static string GetStringValue(Types.TypeValue.StringValue stringValue) => stringValue.Item;

    private decimal GetVariableValue(Types.TypeValue.Variable variable) =>
        _variableService.GetVariableValue(variable.Item);
}