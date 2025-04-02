using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public interface IContextService
{
    StellarisParser.FileContext GetFileContext(string filePath);

    string GetFileContent(string filePath);
}