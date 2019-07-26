using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelPartner.Helpers;

namespace TravelPartner.Model
{
    public class ExchangeRate
    {
        public Dictionary<string, double> rates { get; set; }
        public int Timestamp { get; set; }

        public static async Task<ExchangeRate> GetExchangeRates()
        {
            ExchangeRateRest restClient = new ExchangeRateRest();
            string response = await restClient.GetExchangeRates();
            if (!string.IsNullOrEmpty(response))
                return await DeserializeJson(response);
            return null;
        }

        private static async Task<ExchangeRate> DeserializeJson(string json)
        {
           return await Task<Dictionary<string, double>>.Run(() => 
            {
                RestResult restResult = JsonConvert.DeserializeObject<RestResult>(json);
                Dictionary<string, double> dictionary = new Dictionary<string, double>();
                foreach (var propName in restResult.quotes.Children<JProperty>())
                {
                    string key = propName.Name.Substring(3);
                    double rate = propName.Value.ToObject<double>();
                    dictionary.Add(key, rate);
                }
                return new ExchangeRate() { rates = dictionary, Timestamp = restResult.timestamp}; ;
            });
        }



        private class RestResult
        {
            public bool success { get; set; }
            public string terms { get; set; }
            public string privacy { get; set; }
            public int timestamp { get; set; }
            public string source { get; set; }
            public JObject quotes { get; set; }
        }
    }
}
