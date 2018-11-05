using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proj441
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogPage : ContentPage
	{
		public LogPage ()
		{
			InitializeComponent ();
            PopulateLogList();

        }

        public void PopulateLogList()
        {
            ObservableCollection<Prescription> myPreCollection = new ObservableCollection<Prescription>();
            ListLog.ItemsSource = myPreCollection;
        }

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new AddPerscriptionPage());
        }
    }
}