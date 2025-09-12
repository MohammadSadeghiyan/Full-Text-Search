using QueryParams.Models;
using InvertedIndex.Processing;
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
        if (_invertedIndex.ContainsKey(key))
        {
            if (part.StartsWith("+"))
            {
                context.AtLeastParts.UnionWith(_invertedIndex[key]);
            }
            else if (part.StartsWith("-"))
            {
                context.ExcludeParts.UnionWith(_invertedIndex[key]);
            }
            else
            {
                context.OnlyParts.UnionWith(_invertedIndex[key]);
            }
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
    
    public HashSet<string> ProcessQueryParts(List<string> inputWords)
        {
            QueryContext request = new QueryContext();
            List<string> allParts = TextProcessor.WordStiming(inputWords);

            ProcessAll(request, allParts);
            return request.OnlyParts;
        }
}

