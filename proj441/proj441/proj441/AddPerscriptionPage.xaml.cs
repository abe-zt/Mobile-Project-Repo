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

        public AddPerscriptionPage()
        {
            InitializeComponent();
            FillPickers();
            //InitializeCollection();
        }

        private void FillPickers()
        {
            StrengthPicker.Items.Add("mg");
            StrengthPicker.Items.Add("mcg");
            
            StrengthPicker.SelectedItem = StrengthPicker.Items.FirstOrDefault();        
        }

        //private void StrengthPicker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var chosen = StrengthPicker.Items[StrengthPicker.SelectedIndex];
        //    if (chosen == "mL")
        //    {
        //        preDosage.Text = "1";
        //        preDosage.IsEnabled = false;
        //    }
        //}


        private bool ValidateFields()
        {

            if (preName.Text == null || preName.Text == "")
            {
                return false;
            }

            if (preName.Text.Replace("  ", "") == "")
            {
                return false;
            }
            if (preStrength.Text == null || preStrength.Text == "" || Convert.ToDouble(preStrength.Text) == 0)
            {
                return false;
            }

            if (preDosage.Text == null || preDosage.Text == "" || Convert.ToDouble(preDosage.Text) < 0)
            {
                return false;
            }

            if (preQuantity.Text == null || preQuantity.Text == "" || Convert.ToDouble(preQuantity.Text) < 0)
            {
                return false;
            }

            if (preRemaining.Text == null || preRemaining.Text == "" || Convert.ToDouble(preRemaining.Text) < 0)
            {
                return false;
            }

            return true;
        }

        private async void AddPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            bool valid = ValidateFields();

            if (valid == false)
            {
                await DisplayAlert("Error:", "Please enter valid values for Required (*) fields", "OK");
            }

            else
            {
                bool exists = App.MyPrescrpitions.Any(i => i.Name == preName.Text && i.Strength == preStrength.Text);    //Here comes Linq https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2

                if (exists)
                {
                    await DisplayAlert("Error:", "Prescription already exists", "OK");
                }

                else
                {
                    Prescription p = new Prescription
                    {
                        Name = preName.Text.Trim(),
                        ProperName = preName.Text.ToUpper().Trim(),
                        Strength = (preStrength.Text + StrengthPicker.SelectedItem.ToString()).Trim(),
                        PrescribedDosage = Convert.ToDouble(preDosage.Text),
                        Instructions = preInstructions.Text.Trim(),
                        PhysicalDescription = preDescription.Text.Trim(),
                        Quantity = Convert.ToDouble(preQuantity.Text.Trim()),
                        Remaining = Convert.ToDouble(preRemaining.Text.Trim())
                    };

                    App.MyPrescrpitions.Add(p);
                    await App.MyPrescriptionDatabase.SaveItemAsync(p);
                    await Navigation.PopAsync();
                }
            }
        }

        private void preQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            preRemaining.Text = preQuantity.Text;
        }
    }
}