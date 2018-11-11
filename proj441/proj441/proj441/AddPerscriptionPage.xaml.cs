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
            Prescription p = new Prescription
            {
                Name = preName.Text,
                Strength = preStrength.Text,
                PrescribedDosage = Convert.ToInt32(preDosage.Text),
                Instructions = preInstructions.Text,
                PhysicalDescription = preDescription.Text,
                Quantity = Convert.ToInt32(preQuantity.Text),
                Remaining = Convert.ToInt32(preRemaining.Text)
            };

            App.MyPrescrpitions.Add(p);
            //LogPage logPage = new LogPage(p1);
            await Navigation.PopAsync();
        }
    }
}