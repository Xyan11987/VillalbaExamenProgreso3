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
            _database.CreateTableAsync<Country>().Wait(); // Asegura que la tabla esté creada
        }

        // Guardar país en la base de datos
        public Task<int> SaveCountryAsync(Country country)
        {
            return _database.InsertAsync(country);
        }

        // Obtener todos los países de la base de datos
        public Task<List<Country>> GetCountriesAsync()
        {
            return _database.Table<Country>().ToListAsync();
        }
    }
}
