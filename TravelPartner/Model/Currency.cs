using SQLite;
using System;
using System.Collections.Generic;
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
            get => name; set
            {
                name = value.ToLower();
            }
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
    }
}
