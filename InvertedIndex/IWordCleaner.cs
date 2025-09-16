namespace FullTextSearch.InvertedIndex.Abstractions;

public interface IWordCleaner
{
    public string CleanWord(string fileContent);
   
}