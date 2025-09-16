namespace FullTextSearch.Application;
using FullTextSearch.InvertedIndex.Indexing;
using FullTextSearch.QueryParams.Processor;
using FullTextSearch.Request.Processor;
using FullTextSearch.FileAccess.Reader.FileSpace;
using FullTextSearch.FileAccess.Reader.FolderSpace;
using FullTextSearch.InvertedIndex.Abstractions;
using FullTextSearch.InvertedIndex.Storage;
using FullTextSearch.FileAccess.Processing;
using FullTextSearch.FileAccess.Abstractions;
using FullTextSearch.InvertedIndex.Processing;
using FullTextSearch.InvertedIndex.Tokenizer;
using FullTextSearch.InvertedIndex.Cleaner;
using FullTextSearch.InvertedIndex.StopWordRemover;
using FullTextSearch.InvertedIndex.WordStimmer;
using FullTextSearch.Request.Abstractions;
using FullTextSearch.Request.Result;
public class SearchApplication
{
    private readonly IFolderReader _dataReader;
    private readonly IInvertedIndexStorage _storage;
    private readonly InvertedIndexBuilder _builder;
    private readonly IFileReader _fileReader;
    private readonly ITokenizer _tokenizer;
    private readonly IStopWordRemover _remover;
    private readonly IWordCleaner _cleaner;
    private readonly IWordStemmer _stemmer;
    private readonly TextProcessor _textProcessor;
    private readonly FileProcessor _fileProcessor;
    private readonly RequestProcessor _requestProcessor;
    private readonly IResultRequest _resultRequest;
    public SearchApplication()
    {
        _dataReader = new FolderReder("/home/mohammad/dotnet/full-text-search/Full-Text-Search/search_data/data/EnglishData");
        _storage = new MemoryStorage();
        _builder = new InvertedIndexBuilder(_storage);
        _fileReader = new FileReader();
        _tokenizer = new RegexTokenizer();
        _cleaner = new RegexWordCleaner();
        _remover = new EnglishStopWordRemover();
        _stemmer = new EnglishWordStemmer();
        _textProcessor = new TextProcessor(_tokenizer, _cleaner, _remover, _stemmer);
        _fileProcessor = new FileProcessor(_fileReader, _textProcessor, _builder);
        _requestProcessor = new RequestProcessor();
        _resultRequest = new ConsoleResultRequest();
    }

    public void Run()
        {
            IndexFiles();
            ProcessQuery();
        }

    private void IndexFiles()
    {
        foreach (string file in _dataReader.GetDirectoryFiles())
        {
            _fileProcessor.ProcessFile(file);
        }
    }

    private void ProcessQuery()
    {
        string inputWords = _requestProcessor.ClientRequestProcess();
        var queryProcessor = new QueryProcessor(_storage, _textProcessor);
        HashSet<string> result = queryProcessor.ProcessQueryParts(inputWords);
        _resultRequest.ResultRequest(result);
    }
    
}
