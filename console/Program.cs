using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using InvertedIndex;
namespace FullTextSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> invertedIndex = new Dictionary<string, List<string>>();
            string folderPath = "/home/mohammad/dotnet/full-text-search/search_data/data/EnglishData";
            string[] files = Directory.GetFiles(folderPath);
            string content;
            List<string> allWord = new List<string>();
            foreach (string file in files)
            {
                //read file
                content = File.ReadAllText(file);
                List<string> rawWords = Tokenization.Spilit(content);
                //tokenization
                foreach (string word in rawWords)
                {
                    allWord.Add(Tokenization.CleanWord(word));

                }

                allWord = Tokenization.DeleteStopWords(allWord);

                allWord = Tokenization.WordStiming(allWord);

                Tokenization.BuildInvertedIndex(ref invertedIndex, allWord, file);
                allWord.Clear();
            }

            Console.Write("please enter your string that you want to make full text search on it (hey):");
            string input = Console.ReadLine();
            List<string> parts = Regex.Split(input, @"\s+").ToList();

            HashSet<string> onlyParts = new HashSet<string>();
            HashSet<string> excludeParts = new HashSet<string>();
            HashSet<string> atLeastParts = new HashSet<string>();
            List<string> allParts = Tokenization.WordStiming(parts);

            foreach (var part in allParts)
            {
                if (part.StartsWith("+"))
                {
                    string key = part.Substring(1);
                    if (invertedIndex.ContainsKey(key))
                        atLeastParts.UnionWith(invertedIndex[key]);
                }
                else if (part.StartsWith("-"))
                {
                    string key = part.Substring(1);
                    if (invertedIndex.ContainsKey(key))
                        excludeParts.UnionWith(invertedIndex[key]);
                }
                else
                {
                    string key = part;
                    if (invertedIndex.ContainsKey(key))
                        onlyParts.UnionWith(invertedIndex[key]);
                }
            }


            onlyParts.ExceptWith(excludeParts);
            if (atLeastParts.Count > 0)
                onlyParts.IntersectWith(atLeastParts);

            foreach (var doc in onlyParts)
            {
                Console.WriteLine(doc);
            }








        }
    }
}
