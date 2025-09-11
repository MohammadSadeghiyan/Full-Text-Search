using System.Text.RegularExpressions;
using InvertedIndex.IO;
using QueryParams.Models;
using QueryParams.Services;
using InvertedIndex.Processing;
using InvertedIndex.Indexing;
namespace FullTextSearch
{
    class Program
    {

        
      

        static void ProcessFile(string file)
        {
            FileReader dataReader = new FileReader("/home/mohammad/dotnet/full-text-search/search_data/data/EnglishData");
            List<string> rawWords = dataReader.ReadFileContent(file);
            List<string> processedWords = TextProcessor.ProcessWords(rawWords);
            InvertedIndexBuilder builder = new InvertedIndexBuilder();
            builder.BuildInvertedIndex(processedWords, file);
        }

        static void MessageShowToHelpClientRequest()
        {           
            Console.Write("please enter your string that you want to make full text search on it (hey):");

            
        }
        static string GetInputRequest()
        {
            return  Console.ReadLine();

        }

        static List<string>SplitRequestInput(string input)
        {
            return Regex.Split(input, @"\s+").ToList();

        }
        static List<string> ClientRequestProcess()
        {
            MessageShowToHelpClientRequest();
            string input=GetInputRequest();
            return SplitRequestInput(input);
        }



        static HashSet<string> ProcessQueryParts(List<string> inputWords, Dictionary<string, List<string>> invertedIndex)
        {
            QueryContext request = new QueryContext();
            List<string> allParts = TextProcessor.WordStiming(inputWords);

            QueryProcessor processor = new QueryProcessor(invertedIndex);
            processor.ProcessAll(request, allParts);
            return request.OnlyParts;
        }

        static void GetOutput(HashSet<string> result)
        {
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
        
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> invertedIndex = new Dictionary<string, List<string>>();
            FileReader dataReader = new FileReader("/home/mohammad/dotnet/full-text-search/search_data/data/EnglishData");
            foreach (string file in dataReader.GetDirectoryFiles())
            {
                ProcessFile(file);
            }

            List<string> inputWords = ClientRequestProcess();

            HashSet<string> result = ProcessQueryParts(inputWords, invertedIndex);

            GetOutput(result);
        }
    }
}
