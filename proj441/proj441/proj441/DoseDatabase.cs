using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace proj441
{
    public class DoseDatabase
    {
        readonly SQLiteAsyncConnection database;

        public DoseDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Dose>().Wait();
        }

        public Task<List<Dose>> GetItemsAsync()
        {
            return database.Table<Dose>().ToListAsync();
        }

        public Task<Dose> GetItemAsync(int did)
        {
            return database.Table<Dose>().Where(i => i.DID == did).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Dose item)
        {
            if (item.DID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Dose item)
        {
            return database.DeleteAsync(item);
        }
    }
}
