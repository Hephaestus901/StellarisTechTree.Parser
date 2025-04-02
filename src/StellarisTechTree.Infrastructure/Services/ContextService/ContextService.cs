using System.IO;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public class ContextService : IContextService
{
    public string GetFileContent(string filePath) => File.ReadAllText(filePath);
}