using StellarisTechTree.Domain.Entity;

namespace StellarisTechTree.Infrastructure.Services.ContextService;

public interface IContextService
{
    FileContent GetFileContent(string filePath);
}