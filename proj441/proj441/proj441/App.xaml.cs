using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace proj441
{
    public partial class App : Application
    {

        public static ObservableCollection<Prescription> MyPrescrpitions { get; set; } = new ObservableCollection<Prescription>()
        {
            new Prescription()
            {
                Name = "IBUPROFEN", 
                Strength = "200",
                Instructions = "Take 2 for pain",
                PrescribedDosage = 2,
                PhysicalDescription = "oval, white",
                Quantity = 100,
                Remaining = 100

            }
        };
        public static ObservableCollection<Dose> MyHistory { get; set; } = new ObservableCollection<Dose>();

        public App()
        {
            InitializeComponent();
            MainPage = new proj441.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("uwp=cbe8cd48-61c3-4a94-a7a6-302c4966a423;" +
                  "android={6d344194-1ae6-4575-b5d0-293ecda8a258;}" +
                  "ios={cbbd70a0-4b17-4f6c-8093-103b181f2fb3}",
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
