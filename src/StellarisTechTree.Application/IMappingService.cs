using Microsoft.FSharp.Collections;
using StellarisTechTree.Functional;

namespace StellarisTechTree.Application;

public interface IMappingService
{
    KeyValuePair<string, object> MapToObject(Types.Property parsedContent);

    Dictionary<string, string> MapToObject(FSharpList<Types.LocaleObject> parsedContent);
}