using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngines.Shared
{
    public class Search
    {
        private readonly IEnumerable<ISearchEngine> _searchEngines;

        public Search(IEnumerable<ISearchEngine> searchEngines)
        {
            _searchEngines = searchEngines;
        }

        public SearchResult ExecuteSearch(params string[] queries)
        {
            SearchResult search = new SearchResult();

            foreach (string query in queries)
            {
                foreach (ISearchEngine searchEngine in _searchEngines)
                {
                    QueryResult queryResult = new QueryResult
                    {
                        Query = query,
                        QuerySearchEngineName = searchEngine.EngineName,
                        QueryResultCount = searchEngine.GetQueryResults(query)
                    };

                    search.Add(queryResult);
                }
            }

            return search;
        }
    }
}
