using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Utilities;
using Utilities.Exceptions;

namespace SearchEngines.Bing
{
    public class BingSearchEngine : ISearchEngine
    {
        public string EngineName
        {
            get { return "Bing"; }
        }

        public long GetQueryResults(string sQuery)
        {
            try
            {
                string uriQuery = HelperMethods.ReadConfigSetting("BingURL")
                    .Replace("{QUERY}", Uri.EscapeDataString(sQuery))
                    .Replace("{BingCustomConfig}", HelperMethods.ReadConfigSetting("BingCustomConfig"));

                WebRequest request = WebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = HelperMethods.ReadConfigSetting("BingAPI");
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();

                BingResponse bingResponse = HelperMethods.Deserialize<BingResponse>(jsonResponse);
                return bingResponse.WebPages.TotalEstimatedMatches;
            }

            catch (Exception ex)
            {
                throw new SearchEngineException(EngineName, ex);
            }
        }
    }
}
