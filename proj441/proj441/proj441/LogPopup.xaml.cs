using Rg.Plugins.Popup.Services;
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
	public partial class LogPopup
	{

        DateTime dt = new DateTime();
        Prescription pre = new Prescription();

        public LogPopup(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;

            pre.CopyPrescription(p);
            DosageStepper.Value = pre.PrescribedDosage;
            dt = DateTime.Now;
            _timePicker.Time = DateTime.Now.TimeOfDay;
        }

        //private void DosageStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
        //   AmountLabel.Text = ((int)DosageStepper.Value).ToString();  //converting from double to int to string
        //}

        private void OnTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Time")
            {
                TimeSpan ts = _timePicker.Time;

                dt = DateTime.Today;

                dt += ts;                   //timespan type can be added to datetime type :)

            }
        }

        private async void AddToHistory_Clicked(object sender, EventArgs e)
        {

            Dose d1 = new Dose
            {
                PrescriptionTaken = pre,
                DateTimeTaken = dt,
                QuantityTaken = (int)DosageStepper.Value
            };


            d1.PrescriptionTaken.Remaining -= d1.QuantityTaken;
            App.MyHistory.Add(d1);
            LogPopupStackLayout.IsVisible = false;
            await DisplayAlert("Added to History:", "Taken " + " ("+ d1.QuantityTaken +") " + d1.PrescriptionTaken.Name + " at " + d1.DateTimeTaken.ToString(), "OK");
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void CancelToHistory_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}