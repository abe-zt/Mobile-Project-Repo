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
	public partial class EditPrescriptionPage : ContentPage
	{
		public EditPrescriptionPage (Prescription prescription)
		{
			InitializeComponent ();
            BindingContext = prescription;
		}

        private async void BackToPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}