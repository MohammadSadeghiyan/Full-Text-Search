
using System.Text.RegularExpressions;
using Porter2Stemmer;
namespace InvertedIndex.Processing;

public class TextProcessor
{
    public static List<string> Spilit(string content)
    {
        return Regex.Split(content, @"\s+").ToList();
    }
    public static string CleanWord(string fileContent)
    {
        string w = Regex.Replace(fileContent, @"[^a-zA-Z0-9#]", "");

        w = w.ToUpper();

        return w;
    }

    public static List<string> DeleteStopWords(List<string> allWords)
    {
        List<string> stopWords = new List<string> { "THE", "I", "WE", "YOU", "HE", "SHE", "IT", "THEY", "ME", "HIM", "HER", "US", "THEM" };

        List<string> filteredWords = new List<string>();
        foreach (string word in allWords)
        {
            if (!stopWords.Contains(word) && word != "")
            {
                filteredWords.Add(word);
            }
        }

        return filteredWords;
    }


    public static List<string> WordStiming(List<string> allWords)
    {
        EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();
        List<string> allRoot = new List<string>();
        foreach (string word in allWords)
        {
            allRoot.Add(stemmer.Stem(word).Value);
        }
        return allRoot;
    }

    public static string WordStiming(string word)
    {
        EnglishPorter2Stemmer stemmer = new EnglishPorter2Stemmer();


        return stemmer.Stem(word).Value;

    }
    
    public static List<string> ProcessWords(List<string> rawWords)
    {
        List<string> allWords = new List<string>();
        foreach (string word in rawWords)
        {
            allWords.Add(CleanWord(word));
        }

        allWords = DeleteStopWords(allWords);
        allWords = WordStiming(allWords);

        return allWords;
    }

}