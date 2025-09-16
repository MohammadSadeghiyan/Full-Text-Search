namespace FullTextSearch.QueryParams.Rule;

using FullTextSearch.InvertedIndex.Abstractions;
using FullTextSearch.QueryParams.Abstractions;
using FullTextSearch.QueryParams.Models;

public class OnlyRule : IQueryRule
{
    public bool CanApply(string part) =>
        !part.StartsWith("+") && !part.StartsWith("-");

    public void Apply(QueryContext context, string part, IInvertedIndexStorage storage)
    {
        var files = storage.GetFiles(part);
        context.OnlyParts.UnionWith(files);
    }
}
