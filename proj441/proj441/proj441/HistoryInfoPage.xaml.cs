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
	public partial class HistoryInfoPage : ContentPage
	{
		public HistoryInfoPage ()
		{
			InitializeComponent ();
		}

        public HistoryInfoPage(Dose dose)
        {
            InitializeComponent();
            BindingContext = dose;
            //doseQuantityLabel.Text = dose.PrescriptionTaken.Quantity.ToString();
            //doseRemainingLabel.Text = dose.PrescriptionTaken.Remaining.ToString();
            //doseTakenLabel.Text = dose.QuantityTaken.ToString();
        }
    }
}