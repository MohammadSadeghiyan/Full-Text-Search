using FullTextSearch.InvertedIndex.Abstractions;
namespace FullTextSearch.InvertedIndex.Tokenizer;
using System.Text.RegularExpressions;

public class RegexTokenizer: ITokenizer
{
    public List<string> Tokenize(string content)
    {
        return Regex.Split(content, @"\s+").ToList();
    
    }
}