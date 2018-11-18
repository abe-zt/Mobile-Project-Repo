using Rg.Plugins.Popup.Services;
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
	public partial class PrescriptionsPage : ContentPage
	{
        //public ObservableCollection<Prescription> myPrescriptionCollection = new ObservableCollection<Prescription>();

        public PrescriptionsPage()
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

        async void Handle_ContextMenuEditButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Prescription)menuItem.CommandParameter;
            await Navigation.PushAsync(new EditPrescriptionPage(contextSelected));
        }

        private async void Handle_ContextMenuDeleteButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Prescription)menuItem.CommandParameter;
            //DisplayAlert("Deleted:", contextSelected.Name, "OK");
            bool answer = await DisplayAlert("Confirm:", "Delete '" + contextSelected.Name + "' ?", "Yes", "No");
            if (answer)
            {
                App.MyPrescrpitions.Remove(contextSelected);
            }
        }

        private async void MyLogList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView l = (ListView)sender;
            Prescription p = (Prescription)l.SelectedItem;
            if (l.SelectedItem != null)
            {
                await PopupNavigation.Instance.PushAsync(new LogPopup(p));

                //Prescription p = (Prescription)l.SelectedItem;
                //bool answer = await DisplayAlert("Confirm:", "Log a dosage of '" + p.Name + "' in Dosage History?", "Yes", "No");
                //if (answer)
                //{
                //    App.MyHistory.Add(p);
                //    l.SelectedItem = null;
                //    //await Navigation.PopToRootAsync();
                //}
                //else
                //{
                //    l.SelectedItem = null;
                //}
            }
            l.SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }

        private void MyLogList_Refreshing(object sender, EventArgs e)
        {
            var listViewToRefresh = (ListView)sender;
            //ClearListView();
            PopulateMyList(App.MyPrescrpitions);
            MyLogList.IsRefreshing = false;
        }


        public void ClearListView()
        {
            MyLogList.ItemsSource = null;
        }

    }
}