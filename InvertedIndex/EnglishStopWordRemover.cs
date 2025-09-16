namespace FullTextSearch.InvertedIndex.StopWordRemover;

using FullTextSearch.InvertedIndex.Abstractions;

public class EnglishStopWordRemover : IStopWordRemover
{
    private readonly List<string> _stopWords = new()
    {
        "THE", "I", "WE", "YOU", "HE", "SHE", "IT", "THEY", "ME", "HIM", "HER", "US", "THEM"
    };
    public List<string> Remove(List<string> words)
    {

        return words.Where(w => !_stopWords.Contains(w) && !string.IsNullOrEmpty(w)).ToList();
    }

}