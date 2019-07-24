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
            SetupTableForFirstTime();
        }

        private async void SetupTableForFirstTime()
        {
            int amount = await database.Table<Currency>().CountAsync();
            if (amount < 168)
            {
                await InsertAll(Constants.GetCountries());
            }
        }

        public async Task<bool> InsertAll(List<Currency> currencies)
        {
            int rows = await database.InsertAllAsync(currencies);
            return rows > 0;
        }

        public void UpdateAll(ICollection<Currency> currencies)
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

        public async Task<List<Currency>> Read(int from, int to)
        {
            List<Currency> list = await database.Table<Currency>().Where(c => c.Id >= from && c.Id < to).ToListAsync();
            return list;
        }
    }
}
