using FullTextSearch.Application;
namespace FullTextSearch;
    class Program
    {

        static void Main(string[] args)
        {
            SearchApplication application = new SearchApplication();
            application.Run();
        }
}
