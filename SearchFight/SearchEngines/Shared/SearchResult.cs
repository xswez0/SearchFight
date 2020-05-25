using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngines.Shared
{
    public class SearchResult : List<QueryResult>
    {
        public Dictionary<string, List<QueryResult>> SearchResultsByQuery
        {
            get
            {
                Dictionary<string, List<QueryResult>> searchResultsByQuery = new Dictionary<string, List<QueryResult>>();
                var groups = this.GroupBy(i => i.Query);
                foreach (var itemGroup in groups)
                {
                    string groupKey = itemGroup.Key;
                    List<QueryResult> results = itemGroup.OrderByDescending(x => x.QueryResultCount).ToList();
                    searchResultsByQuery.Add(groupKey, results);
                }

                return searchResultsByQuery;
            }
        }

        public Dictionary<string, List<QueryResult>> SearchResultsByEngine
        {
            get
            {
                Dictionary<string, List<QueryResult>> searchResultsByEngine = new Dictionary<string, List<QueryResult>>();
                var groups = this.GroupBy(i => i.QuerySearchEngineName);

                foreach (var itemGroup in groups)
                {
                    string groupKey = itemGroup.Key;
                    List<QueryResult> results = itemGroup.OrderByDescending(x => x.QueryResultCount).ToList();
                    searchResultsByEngine.Add(groupKey, results);
                }

                return searchResultsByEngine;
            }
        }

        public QueryResult Max
        {
            get
            {
                return this.OrderByDescending(item => item.QueryResultCount).First();
            }
        }
    }
}
