using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngines.Bing
{
    public class BingResponse
    {
        public string Type { get; set; }
        public WebPages WebPages { get; set; }
    }

    public partial class WebPages
    {
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public long TotalEstimatedMatches { get; set; }
    }
}
