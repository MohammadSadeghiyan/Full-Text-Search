using FullTextSearch.FileAccess.Abstractions;
namespace FullTextSearch.FileAccess.Reader.FolderSpace;

public class FolderReder :IFolderReader
{
    private string _folderPath;

    public string FolderPath
    {
        get { return _folderPath; }
        set { _folderPath = value; }
    }

    public FolderReder(string folderPath)
    {
        FolderPath = folderPath;
    }
    public string[] GetDirectoryFiles()
    {
        return Directory.GetFiles(FolderPath);
    }

}