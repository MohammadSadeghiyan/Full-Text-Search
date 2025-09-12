using System;
using System.Text.RegularExpressions;
namespace Request;

public class RequestProcessor
{
    static void MessageShowToHelpClientRequest()
    {
        Console.Write("please enter your string that you want to make full text search on it (hey):");


    }
    static string GetInputRequest()
    {
        return Console.ReadLine();

    }

    static List<string> SplitRequestInput(string input)
    {
        return Regex.Split(input, @"\s+").ToList();

    }
    public static List<string> ClientRequestProcess()
    {
        MessageShowToHelpClientRequest();
        string input = GetInputRequest();
        return SplitRequestInput(input);
    }
    public static void GetOutput(HashSet<string> result)
        {
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
        
}
