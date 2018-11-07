using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace proj441
{
    public partial class App : Application
    {

        public static ObservableCollection<Prescription> myPrescrpitions { get; set; } = new ObservableCollection<Prescription>();

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
