using Antlr4.Runtime;
using StellarisTechTree.Infrastructure.Antlr.Stellaris;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public class ContextService : IContextService
{
    public StellarisParser.FileContext GetFileContext(string filePath)
    {
        var text = File.ReadAllText(filePath);
        var inputStream = new AntlrInputStream(text);
        var lexer = new StellarisLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new StellarisParser(commonTokenStream);
        return parser.file();
    }

    public string GetFileContent(string filePath) => File.ReadAllText(filePath);
}