using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TravelPartner.Helpers
{
    class ExchangeRateRest
    {
        private HttpClient httpClient;

        public ExchangeRateRest()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetExchangeRates()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet) {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(Constants.EXCHANGE_RATE_URL);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        return content;
                    }
                }catch(Exception e)
                {
                    string ss = e.Message;
                }
            }
            return string.Empty;
        }


    }
}
