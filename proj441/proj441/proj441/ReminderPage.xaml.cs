using Plugin.LocalNotifications;
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
	public partial class ReminderPage : ContentPage
	{
		public ReminderPage ()
		{
			InitializeComponent ();
            PopulateMySetRemindersList();
		}

        private void PopulateMySetRemindersList()
        {
            List<Reminder> remindersSorted = App.MyReminders.OrderByDescending(x => x.DateTimeReminder).ToList();
            MySetRemindersList.ItemsSource = remindersSorted;
        }

        private async void Handle_ContextMenuDeleteButton(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            Reminder contextSelected = (Reminder)menuItem.CommandParameter;
            bool answer = await DisplayAlert("Confirm:", "Delete Reminder for '" + contextSelected.ProperName + contextSelected.Strength + contextSelected.StrengthUnits + " at " + contextSelected.DateTimeReminder.ToString() + "?", "Yes", "No");
            if (answer) 
            {
                App.MyReminders.Remove(contextSelected);

                CrossLocalNotifications.Current.Cancel(contextSelected.RID);

                await App.MyRemindersDatabase.DeleteItemAsync(contextSelected);
            }

            MySetRemindersList_Refreshing(MySetRemindersList, null);
        }

        private async void SetReminderButton2_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Navigation.InsertPageBefore(new SetReminderPage(), this);
            await Navigation.PopAsync();
        }

        private void MySetRemindersList_Refreshing(object sender, EventArgs e)
        {
            var listViewToRefresh = (ListView)sender;
            ClearListView();
            PopulateMySetRemindersList();
            MySetRemindersList.IsRefreshing = false;
        }

        private void ClearListView()
        {
            MySetRemindersList.ItemsSource = null;
        }

        protected override void OnAppearing()
        {
            MySetRemindersList_Refreshing(MySetRemindersList, null);
        }
    }
}