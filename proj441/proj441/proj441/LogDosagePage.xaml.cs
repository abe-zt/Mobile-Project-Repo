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
	public partial class LogDosagePage : ContentPage
	{
		//DateTime dt = new DateTime();
        Prescription pDuplicate = new Prescription();

        public LogDosagePage()
        {
            InitializeComponent();
        }

        public LogDosagePage(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;

            pDuplicate.CopyPrescription(p);
            //AssignInitialDosageStepperValue(); 
            //dt = DateTime.Now;

            myDatePicker.Date = DateTime.Now;
            myDatePicker.MaximumDate = DateTime.Now;
            myTimePicker.Time = DateTime.Now.TimeOfDay;
            AmountLabel.Text = p.PrescribedDosage.ToString();
        }

        private void myDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime newDateTime = e.NewDate + myTimePicker.Time;

            if (newDateTime > DateTime.Now)
            {
                myTimePicker.Time = DateTime.Today.TimeOfDay;
            }
        }

        private void OnTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                //dt = DateTime.Now;
                var timePickerTemp = (TimePicker)sender;
                DateTime newDateTime = myDatePicker.Date + timePickerTemp.Time;

                if (newDateTime >  DateTime.Now)
                {
                    TimeSpan oneDay = new TimeSpan(24, 0, 0);
                    newDateTime -= oneDay;
                    myDatePicker.Date = newDateTime;
                }

                //dt = newDateTime;
            }     
        }

        private void DosageStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AmountLabel.Text = Convert.ToInt32(e.NewValue).ToString();
            //int i = (Convert.ToInt32(remainingLabel.Text)) - (Convert.ToInt32(e.NewValue));
            //remainingLabel.Text = i.ToString();
        }

        private async void AddToHistory_Clicked(object sender, EventArgs e)
        {

            int difference = pDuplicate.Remaining - (int)DosageStepper.Value;
            remainingLabel.Text = difference.ToString();

            Dose d1 = new Dose
            {
                PrescriptionTaken = pDuplicate,
                DateTimeTaken = myDatePicker.Date + myTimePicker.Time,
                QuantityTaken = (int)DosageStepper.Value
            };



            d1.PrescriptionTaken.Remaining -= d1.QuantityTaken;
            App.MyHistory.Add(d1);
            //LogPopupStackLayout.IsVisible = true;
            await DisplayAlert("Added to History:", "Taken " + " (" + d1.QuantityTaken + ") " + d1.PrescriptionTaken.Name + " at " + d1.DateTimeTaken.ToString(), "OK");
            await Navigation.PopAsync();
        }

        private async void CancelToHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}