namespace FullTextSearch.QueryParams.Rule;

using FullTextSearch.InvertedIndex.Abstractions;
using FullTextSearch.QueryParams.Models;
using FullTextSearch.QueryParams.Abstractions;

public class AtLeastRule:IQueryRule
{
    public bool CanApply(string part)
    {
        return part.StartsWith('+');
    }

    public void Apply(QueryContext context, string part, IInvertedIndexStorage storage)
    {
        string key = part.Substring(1);
        var files = storage.GetFiles(key);
        context.ExcludeParts.UnionWith(files);   
         }

}