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
            
            SetupTablesForFirstTime();
        }

        private async void SetupTablesForFirstTime()
        {
            CreateTable<Currency>();
            CreateTable<ChoosenCurrenciesTable>();
            int currencycount = await TableCount<Currency>();
            int choosenCurrencyCount = await TableCount<ChoosenCurrenciesTable>();
            if (currencycount < 168)
                await InsertAll(Constants.GetCountries());

            if (choosenCurrencyCount < 10)
                await InsertAll<ChoosenCurrenciesTable>(Constants.ChoosenCurrencies);
        }
        
        public void CreateTable<T>()
            where T : new()
        {
            database.CreateTableAsync<T>().Wait();
        }

        public async Task<bool> InsertAll<T>(List<T> inputList)
        {
            int rows = await database.InsertAllAsync(inputList);
            return rows > 0;
        }

        public void UpdateAll<T>(ICollection<T> inputList)
        {
            database.UpdateAllAsync(inputList);
        }

        public void Delete<T>(T deleteObject)
        {
            database.DeleteAsync(deleteObject);
        }

        public async Task<List<T>> ReadAll<T>()
            where T : new()
        {
            List<T> list = await database.Table<T>().ToListAsync();
            return list;
        }

        public async Task<List<Currency>> ReadChoosen(int length)
        {
            List<ChoosenCurrenciesTable> choosenCurrencies = await database.Table<ChoosenCurrenciesTable>().ToListAsync();
            AsyncTableQuery<Currency> query = database.Table<Currency>();
            List<Currency> currencies = new List<Currency>();
            for (int i = 0; i < length; i++)
            {
                int index = choosenCurrencies[i].CurrencyId - 1;
                currencies.Add(await query.ElementAtAsync(index));
            } 
            return currencies;
        }

        public async Task<int> TableCount<T>()
            where T: new()
        {
            return await database.Table<T>().CountAsync();
        }

        public async Task<List<Currency>> SearchFor(string text)
        {
            string lowerText = text.ToLower();
            return await database.Table<Currency>().Where(
                c => c.Name.ToLower().Contains(lowerText) || 
                c.ShortName.ToLower().Contains(lowerText)).
                ToListAsync();
        }
    }
}
