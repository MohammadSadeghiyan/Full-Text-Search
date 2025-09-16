namespace FullTextSearch.InvertedIndex.WordStimmer;

using Porter2Stemmer;
using FullTextSearch.InvertedIndex.Abstractions;

public class EnglishWordStemmer:IWordStemmer
{
    public List<string> Stem(List<string> allWords)
    {
        EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();
        List<string> allRoot = new List<string>();
        foreach (string word in allWords)
        {
            allRoot.Add(stemmer.Stem(word).Value);
        }
        return allRoot;
    }

    public string Stem(string word)
    {
        EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();


        return stemmer.Stem(word).Value;

    }
}