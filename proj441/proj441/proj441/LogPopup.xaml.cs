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
		public LogPopup ()
		{
			InitializeComponent ();
		}

        public LogPopup(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;
        }

        private void DosageStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AmountLabel.Text = ((int)DosageStepper.Value).ToString();  //converting from double to int to string
        }
    }
}