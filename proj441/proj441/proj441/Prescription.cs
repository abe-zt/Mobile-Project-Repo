using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Prescription : Pills
    {
        [PrimaryKey, AutoIncrement]
        public int PID { get; set; }  
    }
}
