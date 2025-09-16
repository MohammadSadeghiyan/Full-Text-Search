namespace FullTextSearch.InvertedIndex.Abstractions;

public interface IInvertedIndexStorage
{
    void Save(string word, string fileName);
    List<string> GetFiles(string word);
}