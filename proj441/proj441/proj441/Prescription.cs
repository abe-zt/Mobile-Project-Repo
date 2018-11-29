using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Prescription
    {
        [PrimaryKey, AutoIncrement]
        public int PID { get; set; }

        public string Name
        {
            get;
            set;
        }

        public string Strength
        {
            get;
            set;
        }

        public string Instructions
        {
            get;
            set;
        }

        public int PrescribedDosage
        {
            get;
            set;
        }

        public string PhysicalDescription
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int Remaining
        {
            get;
            set;
        }
    }
}
