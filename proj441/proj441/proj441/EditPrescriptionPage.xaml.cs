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
        int originalPID = 0;

        public EditPrescriptionPage (Prescription p)
		{
			InitializeComponent ();
            BindingContext = p;
            originalPID = p.PID;
		}


        private async void BackToPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            Prescription pUpdated = new Prescription
            {
                PID = originalPID,
                Name = preName.Text.ToUpper(),
                Strength = preStrength.Text,
                PrescribedDosage = Convert.ToInt32(preDosage.Text),
                Instructions = preInstructions.Text,
                PhysicalDescription = preDescription.Text,
                Quantity = Convert.ToInt32(preQuantity.Text),
                Remaining = Convert.ToInt32(preRemaining.Text)
            };

            await App.MyPrescriptionDatabase.SaveItemAsync(pUpdated);
            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}