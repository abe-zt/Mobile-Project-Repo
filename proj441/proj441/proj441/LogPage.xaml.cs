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
        public ObservableCollection<Prescription> myPrescriptionCollection = new ObservableCollection<Prescription>();

        public LogPage()
        {
            InitializeComponent();
        }

        public LogPage (Prescription p)
		{
			InitializeComponent ();
            AddMyPrescription(p);
            PopulateMyList(myPrescriptionCollection);
        }

        private void AddMyPrescription(Prescription p)
        {
            myPrescriptionCollection.Add(p);
        }

        private void PopulateMyList(ObservableCollection<Prescription> o)
        {
            MyList.ItemsSource = o;
        }

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            await Navigation.PushAsync(new AddPerscriptionPage());
        }
    }
}