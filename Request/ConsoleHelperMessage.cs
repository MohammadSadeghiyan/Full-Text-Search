namespace FullTextSearch.Request.HelperMessage;

using FullTextSearch.Request.Abstractions;

public class ConsoleHelperMessage:IHelperMessage
{
    public void MessageShowToHelpClientRequest()
    {
        Console.Write("please enter your string that you want to make full text search on it :");

    }
}