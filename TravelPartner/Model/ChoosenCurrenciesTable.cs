using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelPartner.Model
{
    public class ChoosenCurrenciesTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CurrencyId { get; set; }

        public static async void Update(List<Currency> currencies)
        {
            List<ChoosenCurrenciesTable> updateList = await CreateChoosenCurrencies(currencies);
            App.Database.UpdateAll<ChoosenCurrenciesTable>(updateList);
        }

        public static async Task<List<Currency>> GetChoosenCurrencies(int length)
        {
            List<Currency> choosenCurrencies = await App.Database.ReadChoosen(length);
            for (int i = 0; i < length; i++)
                choosenCurrencies[i].Position = i;
            return choosenCurrencies;
        }

        private static async Task<List<ChoosenCurrenciesTable>> CreateChoosenCurrencies(List<Currency> currencies)
        {
            List<ChoosenCurrenciesTable> choosenCurrencies = await App.Database.ReadAll<ChoosenCurrenciesTable>();
            for (int i = 0; i < currencies.Count; i++)
            {
                var currency = currencies[i];
                var choosenCurrency = choosenCurrencies[currency.Position];
                choosenCurrency.CurrencyId = currency.Id;                
            }
            return choosenCurrencies;
        }
    }
}
