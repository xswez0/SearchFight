using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngines.Shared
{
    public class QueryResult
    {
        public string QuerySearchEngineName { get; set; }
        public string Query { get; set; }
        public long QueryResultCount { get; set; }


        public override string ToString()
        {
            return String.Format("{0}:{1}", QuerySearchEngineName, QueryResultCount);
        }
    }
}
