namespace FullTextSearch.Request.HelperMessage;

using FullTextSearch.Request.Abstractions;
using System;
public class ConsoleHelperMessage:IHelperMessage
{
    public void ShowHelperRequestMessage()
    {
        Console.Write("please enter your string that you want to make full text search on it (hey):");

    }

}
