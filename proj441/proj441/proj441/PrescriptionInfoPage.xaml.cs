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
	public partial class PrescriptionInfoPage : ContentPage
	{
		public PrescriptionInfoPage ()
		{
			InitializeComponent();
		}

        public PrescriptionInfoPage(Prescription prescription)
        {
            InitializeComponent();
            BindingContext = prescription;
            QuantityLabel.Text = prescription.Quantity.ToString();
            //RemainingLabel.Text = prescription.Remaining.ToString();
        }
    }
}