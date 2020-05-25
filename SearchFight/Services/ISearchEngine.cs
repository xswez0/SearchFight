using System;

namespace Services
{
    public interface ISearchEngine
    {
        string EngineName { get; }
        long GetQueryResults(string sQuery);
    }
}
