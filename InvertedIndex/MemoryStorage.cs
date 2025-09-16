namespace FullTextSearch.InvertedIndex.Storage;
using FullTextSearch.InvertedIndex.Abstractions;
public class MemoryStorage : IInvertedIndexStorage
{
    private Dictionary<string, List<string>> _data = new();

    public void Save(string word, string fileName)
    {
        if (!_data.ContainsKey(word))
            _data[word] = new List<string>();

        if (!_data[word].Contains(fileName)) 
            _data[word].Add(fileName);
    }

    public List<string> GetFiles(string word)
    {
        return _data.ContainsKey(word) ? _data[word] :  new List<string>();
    }
}