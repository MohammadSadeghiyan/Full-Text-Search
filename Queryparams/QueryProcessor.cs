using FullTextSearch.QueryParams.Models;
using FullTextSearch.InvertedIndex.Abstractions;
using FullTextSearch.InvertedIndex.Processing;
namespace FullTextSearch.QueryParams.Processor;

using FullTextSearch.QueryParams.Rule;
using FullTextSearch.QueryParams.Abstractions;
public class QueryProcessor
{
    private readonly  IInvertedIndexStorage _invertedIndexStorage;
    private readonly TextProcessor _textProcessor;
    private readonly List<IQueryRule> _rules;

    public QueryProcessor(IInvertedIndexStorage storage,TextProcessor processor)
    {
        _invertedIndexStorage = storage;
        _textProcessor = processor;
         _rules = new List<IQueryRule>
        {
            new AtLeastRule(),
            new ExcludeRule(),
            new OnlyRule()
        };
    }

    private void ProcessPart(QueryContext context, string part)
    {
         foreach (var rule in _rules)
        {
            if (rule.CanApply(part))
            {
                rule.Apply(context, part, _invertedIndexStorage);
                break;
            }
        }

    }

    private void ProcessAll(QueryContext context, List<string> parts)
    {
        foreach (string part in parts)
            ProcessPart(context, part);

        context.OnlyParts.ExceptWith(context.ExcludeParts);
        if (context.AtLeastParts.Count > 0)
            context.OnlyParts.IntersectWith(context.AtLeastParts);
    }

    
    
    public HashSet<string> ProcessQueryParts(string inputWords)
        {
            QueryContext request = new QueryContext();
            
            List<string> allParts = _textProcessor.Process(inputWords);

            ProcessAll(request, allParts);
            return request.OnlyParts;
        }
}

