namespace StellarisTechTree.Domain.Services;

public interface IFileService
{
    string[] GetFiles(string sectionName);

    StellarisParser.FileContext GetFileContext(string filePath);
}