
namespace FullTextSearch.InvertedIndex.Abstractions;

public interface ITokenizer
{

    public  List<string> Tokenize(string content);
    
}