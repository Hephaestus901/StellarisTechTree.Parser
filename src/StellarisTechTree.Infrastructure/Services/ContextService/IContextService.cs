using StellarisTechTree.Infrastructure.Antlr.Stellaris;
using StellarisTechTree.Infrastructure.Antlr.StellarisLocale;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public interface IContextService
{
    StellarisParser.FileContext GetFileContext(string filePath);

    StellarisLocaleParser.LocaleFileContext GetLocaleFileContext(string filePath);
}