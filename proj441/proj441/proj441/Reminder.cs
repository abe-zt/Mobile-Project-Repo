//﻿Reminder.cs

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proj441
{
    public class Reminder : Pills
    {
        [PrimaryKey, AutoIncrement]
        public int RID { get; set; }

        public DateTime DateTimeReminder
        {
            get;
            set;
        }
    }
}