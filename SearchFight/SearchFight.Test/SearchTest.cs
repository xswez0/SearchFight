using SearchEngines.Shared;
using NUnit.Framework;

namespace SearchFight.Test
{
    [TestFixture]
    public class SearchTest
    {
        [Test]
        public void SearchResult_Expected_Max()
        {
            SearchResult searchResult = new SearchResult
            {
                new QueryResult()
                {
                    Query = ".net",
                    QuerySearchEngineName = "ENGINE1",
                    QueryResultCount = 1500
                },

                new QueryResult()
                {
                    Query = "java script",
                    QuerySearchEngineName = "ENGINE2",
                    QueryResultCount = 750
                }
            };

            Assert.IsTrue(searchResult.Max.QueryResultCount == 1500);
        }
    }
}
