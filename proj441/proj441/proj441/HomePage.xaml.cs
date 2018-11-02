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

        private async void LogDosageButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new LogPage());
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
    }
}