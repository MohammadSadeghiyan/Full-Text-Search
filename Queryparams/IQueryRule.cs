namespace FullTextSearch.QueryParams.Abstractions;

using FullTextSearch.QueryParams.Models;
using FullTextSearch.InvertedIndex.Abstractions;
public interface IQueryRule
{
    public bool CanApply(string part);
    public void Apply(QueryContext context, string part, IInvertedIndexStorage storage);
}
