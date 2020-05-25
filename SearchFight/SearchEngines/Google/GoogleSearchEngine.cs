using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Utilities;
using Utilities.Exceptions;

namespace SearchEngines.Google
{
    public class GoogleSearchEngine : ISearchEngine
    {
        public string EngineName
        {
            get { return "Google"; }
        }

        public long GetQueryResults(string sQuery)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string uriQuery = HelperMethods.ReadConfigSetting("GoogleURL")
                        .Replace("{QUERY}", Uri.EscapeDataString(sQuery))
                        .Replace("{GoogleAPI}", HelperMethods.ReadConfigSetting("GoogleAPI"))
                        .Replace("{GoogleCSE}", HelperMethods.ReadConfigSetting("GoogleCSE"));

                    string jsonResult = client.DownloadString(uriQuery);
                    GoogleResult googleResult = HelperMethods.Deserialize<GoogleResult>(jsonResult);

                    return long.Parse(googleResult.searchInformation.totalResults);
                }

                catch (Exception ex)
                {
                    throw new SearchEngineException(EngineName, ex);
                }
            }
        }
    }
}
