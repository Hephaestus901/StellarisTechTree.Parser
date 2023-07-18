namespace StellarisTechTree.Domain.Extensions;

public static class DictionaryExtensions
{
    public static Dictionary<TKey, TValue> ConcatDict<TKey, TValue>(
        this Dictionary<TKey, TValue> source,
        Dictionary<TKey, TValue> value) where TKey : notnull =>
        source.Concat(value).ToDictionary(kp => kp.Key, kp => kp.Value);
}