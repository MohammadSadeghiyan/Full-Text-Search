namespace FullTextSearch.Request.GetInput;

using System;
using FullTextSearch.Request.Abstractions;

public class GetConsoleInput : IGetInput
{
    public string GetInputRequest()
    {
        return Console.ReadLine();

    }
}