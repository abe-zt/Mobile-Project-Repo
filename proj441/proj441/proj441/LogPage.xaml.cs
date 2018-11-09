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
        //public ObservableCollection<Prescription> myPrescriptionCollection = new ObservableCollection<Prescription>();

        public LogPage()
        {
            InitializeComponent();
            PopulateMyList(App.MyPrescrpitions);
        }

  //      public LogPage (Prescription p)
		//{
		//	InitializeComponent ();
  //          //AddMyPrescription(p);
  //          PopulateMyList(App.myPrescrpitions);
  //      }

        //private void AddMyPrescription(Prescription p)
        //{
        //}

        private void PopulateMyList(ObservableCollection<Prescription> o)
        {
            MyLogList.ItemsSource = o;
        }

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            await Navigation.PushAsync(new AddPerscriptionPage());
        }

        async void Handle_ContextMenuInfoButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Prescription)menuItem.CommandParameter;
            await Navigation.PushAsync(new PrescriptionInfoPage(contextSelected));
        }

        private void Handle_ContextMenuDeleteButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Prescription)menuItem.CommandParameter;
            DisplayAlert("Deleted:", contextSelected.Name, "OK");

            App.MyPrescrpitions.Remove(contextSelected);
        }

        private void MyLogList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView l = (ListView)sender;
            Prescription p = (Prescription)l.SelectedItem;
            App.MyHistory.Add(p);
        }
    }
}