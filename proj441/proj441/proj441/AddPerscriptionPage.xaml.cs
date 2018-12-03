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
            FillPicker();
            //InitializeCollection();
        }

        //public void InitializeCollection()
        //{
        //    myPreCollection = new ObservableCollection<Prescription>();
        //}

        private void FillPicker()
        {
            StrengthPicker.Items.Add("mg");
            StrengthPicker.Items.Add("mcg");
            StrengthPicker.Items.Add("mL");
            StrengthPicker.SelectedItem = StrengthPicker.Items.FirstOrDefault();
        }

        private void StrengthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chosen = StrengthPicker.Items[StrengthPicker.SelectedIndex];
            if (chosen == "mL")
            {
                preDosage.Text = "1";
                preDosage.IsEnabled = false;
            }
        }
    

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            bool exists = App.MyPrescrpitions.Any(i => i.Name == preName.Text && i.Strength == preStrength.Text);    //Here comes Linq https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2
            if (exists)
            {
                await DisplayAlert("Error:", "Prescription already exists", "OK");
            }

            else if (ValidateFields())
            {         


                Prescription p = new Prescription
                {
                    Name = preName.Text,
                    ProperName = preName.Text.ToUpper(),
                    Strength = preStrength.Text + StrengthPicker.SelectedIndex.ToString(),
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

            else
            {
                await DisplayAlert("Error:", "Please enter valid values for Required (*) fields", "OK");
            }

        }

        private bool ValidateFields()
        {
            int length = preName.Text.Replace("  ", "").Length;
            if (preName.Text == null || preName.Text == "" || length == 0)
                return false;
            if (preStrength.Text == null || preStrength.Text == "" || Convert.ToInt32(preStrength.Text) == 0)
                return false;
            if (preDosage.Text == null || preDosage.Text == "" || Convert.ToInt32(preDosage.Text) < 0)
            {
                //if (Convert.ToInt32(preDosage.Text) != 0.5)
                //    await DisplayAlert("Error:", "Please enter a valid Prescribed Dose", "OK");
                return false;
            }
            return true;
        }

        
    }
}