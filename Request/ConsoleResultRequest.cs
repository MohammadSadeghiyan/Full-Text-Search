namespace FullTextSearch.Request.Result;

using FullTextSearch.Request.Abstractions;
public class ConsoleResultRequest:IResultRequest
{
    public void ResultRequest(HashSet<string> result)
    {
         foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
    }
    
}