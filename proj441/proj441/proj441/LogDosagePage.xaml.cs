using System;
using System.Collections.Generic;
using System.Globalization;
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
        Prescription p_copy = new Prescription();

        public LogDosagePage()
        {
            InitializeComponent();
        }

        public LogDosagePage(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;
            CopyPrescription(p_copy,p);


            //p2.CopyPrescription(p);
            ////AssignInitialDosageStepperValue(); 
            ////dt = DateTime.Now;

            //DosageStepper.Value = p.PrescribedDosage;
            myDatePicker.Date = DateTime.Now;
            myDatePicker.MaximumDate = DateTime.Now;
            myTimePicker.Time = DateTime.Now.TimeOfDay;
            //AmountLabel.Text = p.PrescribedDosage.ToString();
        }

        //copy constructor
        public void CopyPrescription(Prescription new_p, Prescription pervious_p)
        {
            new_p.Name = pervious_p.Name;
            new_p.Strength = pervious_p.Strength;
            new_p.Instructions = pervious_p.Instructions;
            new_p.PrescribedDosage = pervious_p.PrescribedDosage;
            new_p.PhysicalDescription = pervious_p.PhysicalDescription;
            new_p.Quantity = pervious_p.Quantity;
            new_p.Remaining = pervious_p.Remaining;
        }

        private void MyDatePicker_DateSelected(object sender, DateChangedEventArgs e)
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

            //AmountLabel.Text = Convert.ToInt32(e.NewValue).ToString();
            //int i = (Convert.ToInt32(remainingLabel.Text)) - (Convert.ToInt32(e.NewValue));
            //remainingLabel.Text = i.ToString();
        }

        private async void AddToHistory_Clicked(object sender, EventArgs e)
        {

            //int difference = p2.Remaining - (int)DosageStepper.Value;
            //remainingLabel.Text = difference.ToString();
            p_copy.Remaining -= (int)DosageStepper.Value;
            remainingLabel.Text = p_copy.Remaining.ToString();

            Dose d1 = new Dose
            {
                Name = p_copy.Name,
                Strength = p_copy.Strength,
                Instructions = p_copy.Instructions,
                PrescribedDosage = p_copy.PrescribedDosage,
                PhysicalDescription = p_copy.PhysicalDescription,
                Quantity = p_copy.Quantity,
                Remaining = p_copy.Remaining,
                DateTimeTaken = myDatePicker.Date + myTimePicker.Time,
                QuantityTaken = (int)DosageStepper.Value
            };
     
            //d1.PrescriptionTaken.Remaining -= d1.QuantityTaken;
            App.MyHistory.Add(d1);
            //LogPopupStackLayout.IsVisible = true;
            await DisplayAlert("Added to History:", "Taken " + " (" + d1.QuantityTaken + ") " + d1.Name + " at " + d1.DateTimeTaken.ToString(), "OK");
            await Navigation.PopAsync();
        }

        private async void CancelToHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            //p2.CopyPrescription(p);
            //AssignInitialDosageStepperValue(); 
            //dt = DateTime.Now;

            //DosageStepper.Value = p.PrescribedDosage;
            //myDatePicker.Date = DateTime.Now;
            //myDatePicker.MaximumDate = DateTime.Now;
            //myTimePicker.Time = DateTime.Now.TimeOfDay;
            //AmountLabel.Text = p2.PrescribedDosage.ToString();
        }

    }
}