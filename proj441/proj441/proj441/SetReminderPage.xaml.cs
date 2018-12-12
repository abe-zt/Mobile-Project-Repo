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
    public partial class SetReminderPage : ContentPage
    {
        public SetReminderPage()
        {
            InitializeComponent();
            PopulateMyPrescriptionsList();
        }

        private void PopulateMyPrescriptionsList()
        {
            List<Prescription> prescriptionsSortedMultiple = App.MyPrescrpitions.OrderBy(x => x.ProperName).ThenBy(x => x.Strength).ToList();
            MyReminderList.ItemsSource = prescriptionsSortedMultiple;
        }

        private async void AddReminderButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new AddReminderPage());
        }

        private async void MyReminderList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView l = (ListView)sender;
            Prescription p = (Prescription)l.SelectedItem;
            await Navigation.PushAsync(new AddReminderPage(p));
            //l.SelectedItem = null;
        }

        private void MyReminderList_Refreshing(object sender, EventArgs e)
        {
            var listViewToRefresh = (ListView)sender;
            ClearListView();
            PopulateMyPrescriptionsList();
            MyReminderList.IsRefreshing = false;
        }

        private void ClearListView()
        {
            MyReminderList.ItemsSource = null;
        }

        protected override void OnAppearing()
        {
            MyReminderList_Refreshing(MyReminderList, null);
        }
    }
}