
namespace FullTextSearch.QueryParams.Models;

public class QueryContext
{
    private HashSet<string> _onlyParts=new();
    private HashSet<string> _excludeParts=new();
    private HashSet<string> _atLeastParts=new();

    public HashSet<string> OnlyParts
    {
        get { return _onlyParts; }
    }
    public HashSet<string> ExcludeParts
    {
        get { return _excludeParts; }
    }
    public HashSet<string> AtLeastParts
    {
        get { return _atLeastParts; }
    }



    

}
