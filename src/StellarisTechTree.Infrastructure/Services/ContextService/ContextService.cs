using StellarisTechTree.Domain.Entity;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public class ContextService : IContextService
{
    public FileContent GetFileContent(string filePath) => new (filePath, File.ReadAllText(filePath));
}