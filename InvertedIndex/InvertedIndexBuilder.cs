namespace FullTextSearch.InvertedIndex.Indexing;

using FullTextSearch.InvertedIndex.Abstractions;

public class InvertedIndexBuilder
{
    private readonly IInvertedIndexStorage _storage;

    public InvertedIndexBuilder(IInvertedIndexStorage storage)
    {
        _storage = storage;
    }

    public void BuildInvertedIndex(List<string> allWords, string fileName)
    {
        foreach (var word in allWords)
        {
            _storage.Save(word, fileName);
        }
    }
    
}