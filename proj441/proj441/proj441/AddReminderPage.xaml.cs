using Microsoft.AppCenter.Analytics;
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
	public partial class AddReminderPage : ContentPage
	{
        Prescription p_copy = new Prescription();

        public AddReminderPage ()
		{
			InitializeComponent ();
		}

        public AddReminderPage(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;
            CopyPrescription(p_copy, p);
            AssignDateTime();
            
        }

        private void AssignDateTime()
        {
            myDatePicker.Date = DateTime.Now;
            myDatePicker.MinimumDate = DateTime.Now;
            myDatePicker.MaximumDate = DateTime.Now.AddYears(1);
            myTimePicker.Time = DateTime.Now.AddMinutes(5).TimeOfDay;
        }

        public void CopyPrescription(Prescription originalP, Prescription copyP)
        {
            originalP.PID = copyP.PID;
            originalP.Name = copyP.Name;
            originalP.ProperName = copyP.ProperName;
            originalP.Strength = copyP.Strength;
            originalP.StrengthUnits = copyP.StrengthUnits;
            originalP.Instructions = copyP.Instructions;
            originalP.PrescribedDosage = copyP.PrescribedDosage;
            originalP.PhysicalDescription = copyP.PhysicalDescription;
            originalP.Quantity = copyP.Quantity;
            originalP.Remaining = copyP.Remaining;
        }

        private void OnTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                //dt = DateTime.Now;
                var timePickerTemp = (TimePicker)sender;
                DateTime newDateTime = myDatePicker.Date + timePickerTemp.Time;

                if (newDateTime < DateTime.Now)
                {
                    TimeSpan oneDay = new TimeSpan(24, 0, 0);
                    newDateTime += oneDay;
                    myDatePicker.Date = newDateTime;
                }

                //dt = newDateTime;
            }
        }

        private async void AddReminder_Clicked(object sender, EventArgs e)
        {
            DateTime selectedDateTime = myDatePicker.Date + myTimePicker.Time;
            if (selectedDateTime > DateTime.Now)
            {

                Reminder r1 = new Reminder
                {
                    //should not need to copy over pid, since we want
                    Name = p_copy.Name,
                    ProperName = p_copy.ProperName,
                    Strength = p_copy.Strength,
                    StrengthUnits = p_copy.StrengthUnits,
                    Instructions = p_copy.Instructions,
                    PrescribedDosage = p_copy.PrescribedDosage,
                    PhysicalDescription = p_copy.PhysicalDescription,
                    Quantity = p_copy.Quantity,
                    Remaining = p_copy.Remaining,
                    DateTimeReminder = myDatePicker.Date + myTimePicker.Time,

                };

                //d1.PrescriptionTaken.Remaining -= d1.QuantityTaken;
                await App.MyRemindersDatabase.SaveItemAsync(r1);
                App.MyReminders.Add(r1);

                CrossLocalNotifications.Current.Show("PILL-BOY", "Time to take " + r1.Name + " " + r1.Strength + r1.StrengthUnits + "!", r1.RID, r1.DateTimeReminder);

                Analytics.TrackEvent("Successfully added reminder");

                await DisplayAlert("Added to Reminders:", "Take " + r1.ProperName +" "+ r1.Strength + r1.StrengthUnits + " at " + r1.DateTimeReminder.ToString(), "OK");
                await Navigation.PopAsync();
            }
            
            else
            {
                await DisplayAlert("Error:", "Please enter valid Date/Time", "OK");
            }
            
        }


        private async void CancelReminder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}