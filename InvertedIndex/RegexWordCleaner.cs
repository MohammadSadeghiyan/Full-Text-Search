using FullTextSearch.InvertedIndex.Abstractions;
namespace FullTextSearch.InvertedIndex.Cleaner;
using System.Text.RegularExpressions;

public class RegexWordCleaner:IWordCleaner
{
    public string CleanWord(string fileContent)
    {
        string cleand = Regex.Replace(fileContent, @"[^a-zA-Z0-9#]", "");

        cleand = cleand.ToUpper();

        return cleand;
    }

}