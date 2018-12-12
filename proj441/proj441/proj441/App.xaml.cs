using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.IO;
using System.Collections.Generic;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace proj441
{
    public partial class App : Application
    {
        public static ObservableCollection<Prescription> MyPrescrpitions { get; set; } = new ObservableCollection<Prescription>();
        public static ObservableCollection<Dose> MyHistory { get; set; } = new ObservableCollection<Dose>();
        public static ObservableCollection<Reminder> MyReminders { get; set; } = new ObservableCollection<Reminder>();

        public App()
        {
            InitializeComponent();
            MainPage = new proj441.MainPage();
            
            
            
            GetAllPrescriptions();
            GetAllDoses();
            GetAllReminders();
        }

        private static PrescriptionDatabase myPrescriptionDatabase;
        public static PrescriptionDatabase MyPrescriptionDatabase
        {
            get
            {
                if (myPrescriptionDatabase == null)
                {
                    myPrescriptionDatabase = new PrescriptionDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PrescriptionSQLite.db3"));
                }
                return myPrescriptionDatabase;
            }
        }

        private static DoseDatabase myDoseDatabase;
        public static DoseDatabase MyDoseDatabase
        {
            get
            {
                if (myDoseDatabase == null)
                {
                    myDoseDatabase = new DoseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DoseSQLite.db3"));
                }
                return myDoseDatabase;
            }
        }

        private static RemindersDatabase myRemindersDatabase;
        public static RemindersDatabase MyRemindersDatabase
        {
            get
            {
                if (myRemindersDatabase == null)
                {
                    myRemindersDatabase = new RemindersDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RemindersSQLite.db3"));
                }
                return myRemindersDatabase;
            }
        }

        async void GetAllPrescriptions()
        {
            MyPrescrpitions.Clear();
            List<Prescription> prescriptions = await MyPrescriptionDatabase.GetItemsAsync();
            prescriptions.ToList().ForEach(MyPrescrpitions.Add);
        }

        async void GetAllDoses()
        {
            MyHistory.Clear();
            List<Dose> doses = await MyDoseDatabase.GetItemsAsync();
            doses.ToList().ForEach(MyHistory.Add);
        }

        async void GetAllReminders()
        {
            MyReminders.Clear();
            List<Reminder> reminders = await MyRemindersDatabase.GetItemsAsync();
            reminders.ToList().ForEach(MyReminders.Add);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("uwp=cbe8cd48-61c3-4a94-a7a6-302c4966a423;" +
                  "android=6d344194-1ae6-4575-b5d0-293ecda8a258;" +
                  "ios=cbbd70a0-4b17-4f6c-8093-103b181f2fb3;",
                  typeof(Analytics), typeof(Crashes));

            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
