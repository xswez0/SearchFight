using Microsoft.Extensions.DependencyInjection;
using SearchEngines.Bing;
using SearchEngines.Google;
using SearchEngines.Shared;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            IEnumerable<ISearchEngine> services = _serviceProvider.GetServices<ISearchEngine>();
            Search searchObj = new Search(services);
            SearchResult searchResultObj = searchObj.ExecuteSearch(args);
            ShowResults(searchResultObj);

            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ISearchEngine, GoogleSearchEngine>();
            collection.AddScoped<ISearchEngine, BingSearchEngine>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        private static void ShowResults(SearchResult searchResult)
        {
            Dictionary<String, List<QueryResult>> searchResultsByQuery = searchResult.SearchResultsByQuery;
            foreach (KeyValuePair<String, List<QueryResult>> queryResults in searchResultsByQuery)
            {
                Console.Write(queryResults.Key + ": ");
                Console.Write(String.Join(" ", queryResults.Value));
                Console.Write(Environment.NewLine);
            }

            Dictionary<String, List<QueryResult>> searchResultsByEngine = searchResult.SearchResultsByEngine;

            foreach (KeyValuePair<String, List<QueryResult>> engineResults in searchResultsByEngine)
            {
                if (engineResults.Value.Count > 0)
                {
                    Console.Write(engineResults.Key + " winner: ");
                    Console.Write(engineResults.Value.First().Query);
                    Console.Write(Environment.NewLine);
                }
            }

            Console.WriteLine("Total winner: " + searchResult.Max.Query);
        }
    }
}
