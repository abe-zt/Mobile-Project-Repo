//using Rg.Plugins.Popup.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace proj441
//{
//	[XamlCompilation(XamlCompilationOptions.Compile)]
//	public partial class LogPopup
//	{

//        DateTime dt = new DateTime();
//        Prescription pre = new Prescription();

//        public LogPopup(Prescription p)
//        {
//            InitializeComponent();
//            BindingContext = p;

//            CopyPrescription(pre, p);
//            //AssignInitialDosageStepperValue();
            
//            dt = DateTime.Now;

//            myDatePicker.Date = dt;
//            myDatePicker.MaximumDate = DateTime.Today;
//            myTimePicker.Time = dt.TimeOfDay;
//            AmountLabel.Text = p.PrescribedDosage.ToString();
//        }

//        //private void AssignInitialDosageStepperValue()
//        //{
//        //    if (pre.PrescribedDosage < DosageStepper.Minimum)
//        //        DosageStepper.Value = DosageStepper.Minimum;
//        //    else if (pre.PrescribedDosage > DosageStepper.Maximum)
//        //        DosageStepper.Value = DosageStepper.Maximum;
//        //    else
//        //        DosageStepper.Value = pre.PrescribedDosage;
//        //}

//        //private void DosageStepper_ValueChanged(object sender, ValueChangedEventArgs e)
//        //{
//        //   AmountLabel.Text = ((int)DosageStepper.Value).ToString();  //converting from double to int to string
//        //}

//        //private void _datePicker_DateSelected(object sender, DateChangedEventArgs e)
//        //{



//        //    //TimeSpan ts2 = dt.TimeOfDay;
//        //    //dt = e.NewDate;
//        //    //dt += ts2;
//        //}

//        private void OnTimePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//        {
//            myDatePicker.Date = dt;

//            //if (e.PropertyName == "Time")
//            //{
//                //TimeSpan ts = _timePicker.Time;
//                //dt = DateTime.Today;

//                //dt += ts;                   //timespan can be added to datetime :)

//                //if (dt > DateTime.Now)
//                //{
//                //    TimeSpan oneDay = new TimeSpan(24,0,0);
//                //    dt -= oneDay;
//                //    _datePicker.Date = dt.Date;
//                //}
//            //}
//        }

//        private async void AddToHistory_Clicked(object sender, EventArgs e)
//        {

//            int difference = pre.Remaining - (int)DosageStepper.Value;
//            remainingLabel.Text = difference.ToString();

//            Dose d1 = new Dose
//            {
//                PrescriptionTaken = pre,
//                DateTimeTaken = dt,
//                QuantityTaken = (int)DosageStepper.Value
//            };

            

//            d1.Remaining -= d1.QuantityTaken;
//            App.MyHistory.Add(d1);
//            LogPopupStackLayout.IsVisible = true;
//            await DisplayAlert("Added to History:", "Taken " + " ("+ d1.QuantityTaken +") " + d1.Name + " at " + d1.DateTimeTaken.ToString(), "OK");
//            await PopupNavigation.Instance.PopAsync(true);
//        }

//        private async void CancelToHistory_Clicked(object sender, EventArgs e)
//        {
//            await PopupNavigation.Instance.PopAsync(true);
//        }

//        private void DosageStepper_ValueChanged(object sender, ValueChangedEventArgs e)
//        {
//            AmountLabel.Text = Convert.ToInt32(e.NewValue).ToString();
//        }

//        private void MyDatePicker_DateSelected(object sender, DateChangedEventArgs e)
//        {

//        }

        
//    }
//}