using Microsoft.Extensions.Configuration;
using StellarisTechTree.Application.Services;

namespace StellarisTechTree.Infrastructure.Services;

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
}