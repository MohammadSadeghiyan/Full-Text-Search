using QueryParams.Models;

namespace QueryParams.Services;

public class QueryProcessor
{
    private readonly Dictionary<string, List<string>> _invertedIndex;

    public QueryProcessor(Dictionary<string, List<string>> invertedIndex)
    {
        _invertedIndex = invertedIndex;
    }

    private void ProcessPart(QueryContext context, string part)
    {
        string key = part.StartsWith("+") || part.StartsWith('-') ? part.Substring(1) : part;
       
        if (part.StartsWith("+"))
        {
            if (_invertedIndex.ContainsKey(key))
                context.AtLeastParts.UnionWith(_invertedIndex[key]);
        }
        else if (part.StartsWith("-"))
        {
            if (_invertedIndex.ContainsKey(key))
                context.ExcludeParts.UnionWith(_invertedIndex[key]);
        }
        else
        {
            if (_invertedIndex.ContainsKey(key))
                context.OnlyParts.UnionWith(_invertedIndex[key]);
        }
    }

    public void ProcessAll(QueryContext context, List<string> parts)
    {
        foreach (string part in parts)
        {
            ProcessPart(context, part);
        }
        context.OnlyParts.ExceptWith(context.ExcludeParts);
        if (context.AtLeastParts.Count > 0)
        context.OnlyParts.IntersectWith(context.AtLeastParts);

    }
}

