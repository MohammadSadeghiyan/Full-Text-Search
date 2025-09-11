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

        static List<string> ReadFileContent(FileReader reader, string file)
        {
            string content = reader.ReadAllSpecificFileContent(file);
            return TextProcessor.Spilit(content);
        }
        static List<string> ProcessWords(List<string> rawWords)
        {
            List<string> allWords = new List<string>();
            foreach (string word in rawWords)
            {
                allWords.Add(TextProcessor.CleanWord(word));
            }

            allWords = TextProcessor.DeleteStopWords(allWords);
            allWords = TextProcessor.WordStiming(allWords);

            return allWords;
        }

        static void ProcessFile(FileReader dataReader, string file, ref Dictionary<string, List<string>> invertedIndex)
        {
            List<string> rawWords = ReadFileContent(dataReader, file);
            List<string> processedWords = ProcessWords(rawWords);
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
                ProcessFile(dataReader, file, ref invertedIndex);
            }

            List<string> inputWords = ClientRequestProcess();

            HashSet<string> result = ProcessQueryParts(inputWords, invertedIndex);

            GetOutput(result);










        }
    }
}
