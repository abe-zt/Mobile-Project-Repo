using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Dose : Pills
    {
        [PrimaryKey, AutoIncrement]
        public int DID { get; set; }

        public DateTime DateTimeTaken
        {
            get;
            set;
        }

        public int QuantityTaken
        {
            get;
            set;
        }
    }
}
