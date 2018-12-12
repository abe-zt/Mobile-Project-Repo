using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace proj441
{
    public class RemindersDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RemindersDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Reminder>().Wait();
        }

        public Task<List<Reminder>> GetItemsAsync()
        {
            return database.Table<Reminder>().ToListAsync();
        }

        public Task<Reminder> GetItemAsync(int rid)
        {
            return database.Table<Reminder>().Where(i => i.RID == rid).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Reminder item)
        {
            if (item.RID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Reminder item)
        {
            return database.DeleteAsync(item);
        }
    }
}
