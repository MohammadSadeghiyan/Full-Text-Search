
namespace FullTextSearch.InvertedIndex.Processing;

using FullTextSearch.InvertedIndex.Abstractions;
public class TextProcessor
{


    private  ITokenizer _tokenizer;
    private  IWordCleaner _cleaner;
    private  IStopWordRemover _stopWordRemover;
    private  IWordStemmer _stemmer;

    public TextProcessor(ITokenizer tokenizer, IWordCleaner cleaner, IStopWordRemover stopWordRemover, IWordStemmer  stemmer)
    {
        _tokenizer = tokenizer;
        _cleaner = cleaner;
        _stopWordRemover = stopWordRemover;
        _stemmer = stemmer;
    }


   
    
   public List<string> Process(string content)
    {
        var tokens = _tokenizer.Tokenize(content);

        var cleaned = tokens.Select(w => _cleaner.CleanWord(w)).ToList();

        var filtered = _stopWordRemover.Remove(cleaned);

        var stemmed = filtered.Select(w => _stemmer.Stem(w)).ToList();

        return stemmed;
    }
}
