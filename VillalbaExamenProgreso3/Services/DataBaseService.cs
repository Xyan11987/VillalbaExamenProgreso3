using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using VillalbaExamenProgreso3.Models;

namespace VillalbaExamenProgreso3.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Country>().Wait();
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await _database.Table<Country>().ToListAsync();
        }

        public async Task SaveCountryAsync(Country country)
        {
            await _database.InsertAsync(country);
        }
    }
}
