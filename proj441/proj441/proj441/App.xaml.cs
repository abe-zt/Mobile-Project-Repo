using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                PhysicalDescription = "oval,white",
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
