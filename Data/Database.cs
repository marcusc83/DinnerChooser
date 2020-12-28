using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinnerChooser.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Searches>().Wait();
        }

        public Task<List<Searches>> GetSearchesAsync()
        {
            return _database.Table<Searches>().ToListAsync();
        }

        public Task<int> SaveSearchesAsync(Searches search)
        {
            return _database.InsertAsync(search);
        }


    }
}
