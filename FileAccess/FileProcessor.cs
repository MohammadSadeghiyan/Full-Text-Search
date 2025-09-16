namespace FullTextSearch.FileAccess.Processing;

using FullTextSearch.FileAccess.Abstractions;
using FullTextSearch.InvertedIndex.Abstractions;
using FullTextSearch.InvertedIndex.Indexing;
using InvertedIndex.Processing;

public class FileProcessor
{
    private  IFileReader _reader;
    private  TextProcessor _processor;
    private  InvertedIndexBuilder _indexBuilder;

    public FileProcessor(
        IFileReader reader,
        TextProcessor processor,
        InvertedIndexBuilder indexBuilder)
    {
        _reader = reader;
        _processor = processor;
        _indexBuilder = indexBuilder;
    }

    public void ProcessFile(string filePath)
    {
        string content = _reader.ReadFileContent(filePath);

        var processedWords = _processor.Process(content);

        _indexBuilder.BuildInvertedIndex(processedWords, filePath);
    }
}
