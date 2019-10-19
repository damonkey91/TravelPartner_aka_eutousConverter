using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPartner.Model
{
    public class Currency
    {
        public const int NO_VALUE = -1;
        private string name;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name
        {
            get => name;
            set => name = value.ToLower();
        }
        public string ShortName { get; set; }
        public double Value { get; set; }
        public int Position { get; set; }
        public Currency()
        {

        }

        public static async Task<List<Currency>> GetAllCurrencies()
        {
            return await App.Database.ReadAll<Currency>();
        }

        public static async Task<List<Currency>> GetCurrenciesContaining(string text)
        {
            return await App.Database.SearchFor(text);
        }

        public static async void UpdateCurrencyValue(ExchangeRate exchangeRate)
        {
            List<Currency> currencies = await App.Database.ReadAll<Currency>();
            currencies = await InsertRateIntoCurrencies(currencies, exchangeRate);
            App.Database.UpdateAll<Currency>(currencies);
        }

        public static async Task<List<Currency>> InsertRateIntoCurrencies(ICollection<Currency> currencies, ExchangeRate exchangeRate)
        {
            return await Task<List<Currency>>.Run(() => 
            {
                Dictionary<string, double> rates = exchangeRate.rates;
                foreach (var currency in currencies)
                {
                    string key = currency.ShortName;
                    double rate = rates[key];
                    currency.Value = rate;
                }
                return currencies.ToList();
            });
            
        }
    }
}
