namespace FullTextSearch.InvertedIndex.Abstractions;
public interface IStopWordRemover
{
    List<string> Remove(List<string> words);
}