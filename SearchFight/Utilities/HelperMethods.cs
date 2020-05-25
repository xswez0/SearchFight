using Newtonsoft.Json;
using System;
using System.Configuration;

namespace Utilities
{
    public static class HelperMethods
    {
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static String ReadConfigSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key];
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading settings");
            }

            return String.Empty;
        }
    }
}
