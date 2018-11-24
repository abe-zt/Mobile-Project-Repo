using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proj441
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //json content https://api.fda.gov/drug/enforcement.json?search=report_date:[20180121+TO+20181121]+AND+city:San Diego&limit=100

        private async void LogDosageButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new PrescriptionsPage());
        }

        private async void SetReminderButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new SetReminderPage());
        }

        private async void SeeRemindersButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new ReminderPage());
        }

        private async void SeeHistoryButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new HistoryPage());
        }

        private async void RecallButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new RecallPage());
        }
    }
}