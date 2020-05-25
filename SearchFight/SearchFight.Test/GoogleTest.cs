using NUnit.Framework;
using SearchEngines.Google;

namespace SearchFight.Test
{
    [TestFixture]
    public class GoogleTest
    {
        [Test]
        public void Google_Query_Positive()
        {
            var googleService = new GoogleSearchEngine();
            long result = googleService.GetQueryResults(".net");

            Assert.IsTrue(result > 0);
        }
        [Test]
        public void Google_QuotationMarks_Positive()
        {
            var googleService = new GoogleSearchEngine();
            long result = googleService.GetQueryResults("\"node js\"");

            Assert.IsTrue(result > 0);
        }
    }
}
