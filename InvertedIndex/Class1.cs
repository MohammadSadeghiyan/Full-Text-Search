using System.IO;
using System.Text.RegularExpressions;
using Porter2Stemmer;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
namespace InvertedIndex;


public class InvertedIndexProcess
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
        List<string> stopWords = new List<string> { "I", "WE", "YOU", "HE", "SHE", "IT", "THEY", "ME", "HIM", "HER", "US", "THEM" };

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
    public static void BuildInvertedIndex(ref Dictionary<string, List<string>> invertedIndex, List<string> allWord, string fileName)
    {
        foreach (var word in allWord)
        {
            if (invertedIndex.ContainsKey(word))
            {
                if (!invertedIndex[word].Contains(fileName))
                    invertedIndex[word].Add(fileName);
            }
            else
            {
                invertedIndex.Add(word, new List<string> { fileName });
            }
        }
    }
}