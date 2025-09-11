using InvertedIndex.Processing;
namespace InvertedIndex.IO;

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

}
