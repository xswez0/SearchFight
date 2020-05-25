using NUnit.Framework;
using SearchEngines.Bing;

namespace SearchFight.Test
{
    [TestFixture]
    public class BingTest
    {
        [Test]
        public void Bing_Query_Positive()
        {
            var bingService = new BingSearchEngine();
            long result = bingService.GetQueryResults(".net");
           
            Assert.IsTrue(result > 0);
        }
        [Test]
        public void Bing_QuotationMarks_Positive()
        {
            var bingService = new BingSearchEngine();
            long result = bingService.GetQueryResults("\"node js\"");
            
            Assert.IsTrue(result > 0);
        }
    }
}