using InvertedIndex.IO;
using QueryParams.Services;
using InvertedIndex.Indexing;
using Request;
namespace FullTextSearch
{
    class Program
    {


        
        static void Main(string[] args)
        {
            FileReader dataReader = new FileReader("/home/mohammad/dotnet/full-text-search/Full-Text-Search/search_data/data/EnglishData");
            InvertedIndexBuilder builder = new InvertedIndexBuilder();
            foreach (string file in dataReader.GetDirectoryFiles())
            {
                FileReader.ProcessFile(file,ref builder);
            }

            List<string> inputWords = RequestProcessor.ClientRequestProcess();

            QueryProcessor processor = new QueryProcessor(builder.InvertedIndex);

            HashSet<string> result = processor.ProcessQueryParts(inputWords);

            RequestProcessor.GetOutput(result);
        }
    }
}
