namespace FullTextSearch.QueryParams.Rule;
using FullTextSearch.QueryParams.Abstractions;
using FullTextSearch.QueryParams.Models;
using FullTextSearch.InvertedIndex.Abstractions;
public class ExcludeRule : IQueryRule
{
    public bool CanApply(string part) => part.StartsWith("-");

    public void Apply(QueryContext context, string part, IInvertedIndexStorage storage)
    {
        string key = part.Substring(1);
        var files = storage.GetFiles(key);
        context.ExcludeParts.UnionWith(files);
    }
}