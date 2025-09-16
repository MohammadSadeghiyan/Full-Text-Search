using FullTextSearch.FileAccess.Abstractions;
namespace FullTextSearch.FileAccess.Reader.FileSpace;

public class FileReader : IFileReader
{
    public string ReadFileContent(string filePath)
    {
        if (File.Exists(filePath))
            return File.ReadAllText(filePath);
        throw new FileNotFoundException("file path dosn't exist");

    }



 
}

