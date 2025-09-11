namespace InvertedIndex.Indexing;


public class InvertedIndexBuilder
{
    private Dictionary<string, List<string>> _invertedIndex= new();

    public Dictionary<string, List<string>> InvertedIndex
    {
        get{ return _invertedIndex; }
    }
    
    public void BuildInvertedIndex(List<string> allWord, string fileName)
    {
        foreach (var word in allWord)
        {
            if (InvertedIndex!=null &&InvertedIndex.ContainsKey(word))
            {
                if (!InvertedIndex[word].Contains(fileName))
                    InvertedIndex[word].Add(fileName);
            }
            else
            {
                InvertedIndex.Add(word, new List<string> { fileName });
            }
        }
    }
}