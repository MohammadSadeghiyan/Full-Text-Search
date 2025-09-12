using InvertedIndex.Processing;
namespace InvertedIndex.IO;
using InvertedIndex.Indexing;

public class FileReader
{

    private string _folderPath;

    public string FolderPath
    {
        get { return _folderPath; }
        set { _folderPath = value; }
    }

    public FileReader(string folderPath)
    {
        _folderPath = folderPath;
    }


    public string[] GetDirectoryFiles()
    {
        return Directory.GetFiles(_folderPath);
    }

    public string ReadAllSpecificFileContent(string file)
    {
        return File.ReadAllText(file);
    }

    public  List<string> ReadFileContent(string file)
    {
        string content = ReadAllSpecificFileContent(file);
        return TextProcessor.Spilit(content);
    }
    public static void ProcessFile(string file,ref InvertedIndexBuilder builder)
        {
            FileReader dataReader = new FileReader("/home/mohammad/dotnet/full-text-search/search_data/data/EnglishData");
            List<string> rawWords = dataReader.ReadFileContent(file);
            List<string> processedWords = TextProcessor.ProcessWords(rawWords);
            builder.BuildInvertedIndex(processedWords, file);
        }
}
