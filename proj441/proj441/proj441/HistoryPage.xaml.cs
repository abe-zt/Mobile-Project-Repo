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
            PopulateMyList(App.MyHistory);
        }

        private void PopulateMyList(ObservableCollection<Dose> o)
        {
            MyHistoryList.ItemsSource = o;
        }

        async void Handle_ContextMenuInfoButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Dose)menuItem.CommandParameter;
            await Navigation.PushAsync(new HistoryInfoPage(contextSelected));
        }

        private async void Handle_ContextMenuDeleteButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextSelected = (Dose)menuItem.CommandParameter;
            bool answer = await DisplayAlert("Confirm:", "Delete '" + contextSelected.PrescriptionTaken.Name + "' ?", "Yes", "No");
            if (answer)
            {
                App.MyHistory.Remove(contextSelected);
            }          
        }

        private async void LogDosageButton2_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new LogPage());
        }



    }
}