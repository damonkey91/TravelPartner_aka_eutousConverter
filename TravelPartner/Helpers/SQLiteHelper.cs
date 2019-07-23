using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TravelPartner.Model;

namespace TravelPartner.Helpers
{
    public class SQLiteHelper
    {
        private SQLiteAsyncConnection database;

        public SQLiteHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Currency>().Wait();
        }

        public async void InsertAll(List<Currency> currencies)
        {
            await database.InsertAllAsync(currencies);
        }

        public void UpdateAll(ObservableCollection<Currency> currencies)
        {
            database.UpdateAllAsync(currencies);
        }

        public void Delete(Currency currency)
        {
            database.DeleteAsync(currency.Id);
        }

        public async Task<List<Currency>> ReadAll()
        {
            List<Currency> currencies = await database.Table<Currency>().ToListAsync();
            return currencies;
        }

        public async Task<List<Currency>> ReadChoosen()
        {
            List<Currency> currencies = await database.Table<Currency>().Where(c => c.Order != Currency.NOT_CHOOSEN).OrderBy(c => c.Order).ToListAsync();
            return currencies;
        }
    }
}
