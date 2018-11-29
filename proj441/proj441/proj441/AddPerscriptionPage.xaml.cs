using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public ObservableCollection<Prescription> myPreCollection;
        

        public AddPerscriptionPage()
        {
            InitializeComponent();
            //InitializeCollection();
        }

        //public void InitializeCollection()
        //{
        //    myPreCollection = new ObservableCollection<Prescription>();
        //}

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            var exists = App.MyPrescrpitions.Any(i => i.Name == preName.Text && i.Strength == preStrength.Text);    //Here comes Linq https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2
            if (exists)
            {
                await DisplayAlert("Error:", "Prescription already exists", "OK");
            }

            else
            {
                Prescription p = new Prescription
                {
                    Name = preName.Text.ToUpper(),
                    Strength = preStrength.Text,
                    PrescribedDosage = Convert.ToInt32(preDosage.Text),
                    Instructions = preInstructions.Text,
                    PhysicalDescription = preDescription.Text,
                    Quantity = Convert.ToInt32(preQuantity.Text),
                    Remaining = Convert.ToInt32(preRemaining.Text)
                };

                App.MyPrescrpitions.Add(p);
                await App.MyPrescriptionDatabase.SaveItemAsync(p);
                //LogPage logPage = new LogPage(p1);
                await Navigation.PopAsync();
            }
        }
    }
}