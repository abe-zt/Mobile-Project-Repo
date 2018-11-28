using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace proj441
{
    public class PrescriptionDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PrescriptionDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Prescription>().Wait();
        }
    }
}
