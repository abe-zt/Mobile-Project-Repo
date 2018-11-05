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
	public partial class AddPerscriptionPage : ContentPage
	{
		public AddPerscriptionPage ()
		{
			InitializeComponent ();
		}

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            Prescription p1 = new Prescription
            {
                Name = preName.Text,
                Strength = preStrength.Text,
                Instructions = preInstructions.Text,
                PhysicalDescription = preDescription.Text,
                Quantity = Convert.ToInt32(preQuantity.Text)
            };

            LogPage logPage = new LogPage();
            logPage.BindingContext = p1;
            await Navigation.PushAsync(logPage);
        }
    }
}