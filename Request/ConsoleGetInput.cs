namespace FullTextSearch.Request.GetInput;

using FullTextSearch.Request.Abstractions;
using System;
public class ConsoleGetInput : IGetInput
{
    public string GetRequest()
    {
        return Console.ReadLine();

    }
}