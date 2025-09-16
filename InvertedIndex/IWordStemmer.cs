namespace FullTextSearch.InvertedIndex.Abstractions;

public interface IWordStemmer
{
    public  List<string> Stem(List<string> allWords);
    public  string Stem(string word);

}