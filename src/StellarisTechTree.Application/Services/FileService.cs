using Antlr4.Runtime;
using Microsoft.Extensions.Configuration;
using StellarisTechTree.Domain.Services;

namespace StellarisTechTree.Application.Services;

public class FileService : IFileService
{
    private readonly IConfiguration configuration;

    public FileService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string[] GetFiles(string sectionName)
    {
        var basePath = configuration.GetSection("BasePath").Value;
        var folderPath = configuration.GetSection($"{sectionName}:Path").Value;
        var extension = configuration.GetSection($"{sectionName}:Extension").Value;
        return Directory.GetFiles(Path.Combine(basePath!, folderPath!), $"*.{extension}");
    }
    
    public StellarisParser.FileContext GetFileContext(string filePath)
    {
        var text = File.ReadAllText(filePath);
        var inputStream = new AntlrInputStream(text);
        var lexer = new StellarisLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);
        var parser = new StellarisParser(commonTokenStream);
        return parser.file();
    }
}