using StellarisTechTree.Infrastructure.Antlr.StellarisLocale;

namespace StellarisTechTree.Infrastructure.Parsers;

public class LocaleVisitor : StellarisLocaleBaseVisitor<Dictionary<string, string>>
{
    private readonly LocaleTopic _localeTopic;

    public LocaleVisitor(LocaleTopic localeTopic)
    {
        _localeTopic = localeTopic;
    }

    public override Dictionary<string, string> VisitLocaleFile(StellarisLocaleParser.LocaleFileContext context)
    {
        switch (_localeTopic)
        {
            case LocaleTopic.Descriptions:
                return FilterLocaleValues(context,
                    value => value.EndsWith("desc", StringComparison.InvariantCultureIgnoreCase) ||
                        value.EndsWith("details", StringComparison.InvariantCultureIgnoreCase));
            case LocaleTopic.Names:
            default:
                return FilterLocaleValues(context,
                    value => !value.EndsWith("desc", StringComparison.InvariantCultureIgnoreCase));
        }
    }

    private Dictionary<string, string> FilterLocaleValues(StellarisLocaleParser.LocaleFileContext context,
        Predicate<string> condition)
    {
        var result = new Dictionary<string, string>();
        foreach (var valueContext in context.localeValue())
        {
            var name = valueContext.BAREWORD().GetText();
            name = name.Remove(name.IndexOf(":", StringComparison.Ordinal));
            if (!condition(name))
            {
                continue;
            }

            var value = valueContext.STRING().GetText().Trim('\"');

            result.TryAdd(name, value);
        }

        return result;
    }
}