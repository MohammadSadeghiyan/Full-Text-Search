namespace FullTextSearch.Request.WordSpiliter;
using System.Text.RegularExpressions;

public class InputWordSpiliter
{
    public List<string> Spilit(string inputContent)
    {
        return Regex.Split(inputContent, @"\s+").ToList();

    }
}