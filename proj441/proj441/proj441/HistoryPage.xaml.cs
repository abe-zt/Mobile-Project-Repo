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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
            PopulateMyHistoryList();
        }

        private void PopulateMyHistoryList()
        {
            List<Dose> historySorted = App.MyHistory.OrderByDescending(x => x.DateTimeTaken).ToList();
            MyHistoryList.ItemsSource = historySorted;
        }

        private async void Handle_ContextMenuDeleteButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Dose)menuItem.CommandParameter;
            bool answer = await DisplayAlert("Confirm:", "Delete '" + contextSelected.Name + "' ?", "Yes", "No");
            if (answer)
            {
                App.MyHistory.Remove(contextSelected);
                await App.MyDoseDatabase.DeleteItemAsync(contextSelected);
            }          
        }

        private async void LogDosageButton2_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new PrescriptionsPage());
        }

        private async void MyHistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView tappedItem = (ListView)sender;
            Dose tappedDose = (Dose)tappedItem.SelectedItem;
            //await Navigation.PushAsync(new HistoryInfoPage(tappedDose));
            await PopupNavigation.Instance.PushAsync(new HistoryInfoPage(tappedDose));
        }
    }
}