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
        }

        private void FillPickers()
        {
            preStrengthUnits.Items.Add("mg");
            preStrengthUnits.Items.Add("mcg");

            preStrengthUnits.SelectedItem = preStrengthUnits.Items.FirstOrDefault();        
        }

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

            if (StrengthSwitch.IsToggled)
            {
                if (preStrength.Text == null || preStrength.Text == "" || Convert.ToDouble(preStrength.Text) == 0)
                {
                    return false;
                }
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
                await DisplayAlert("Error:", "Please enter values for Required (*) fields", "OK");
            }

            else
            {
                ValidateValues();

                bool exists = App.MyPrescrpitions.Any(i => i.ProperName == preName.Text.ToUpper() && i.Strength == preStrength.Text && i.StrengthUnits == preStrengthUnits.SelectedItem.ToString());    //Here comes Linq https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2

                if (exists)
                {
                    await DisplayAlert("Error:", "Prescription already exists", "OK");
                }

                else
                {
                    string s;
                    string su;

                    if(StrengthSwitch.IsToggled)
                    {
                        s = preStrength.Text.Trim();
                        su = preStrengthUnits.SelectedItem.ToString();
                    }
                    else
                    {
                        s = " ";
                        su = " ";
                    }

                    Prescription p = new Prescription
                    {
                        Name = preName.Text.Trim(),
                        ProperName = preName.Text.Trim().ToUpper(),
                        Strength = s,
                        StrengthUnits = su,
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

        private void ValidateValues()
        {
            
        }

        private void PreQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            preRemaining.Text = preQuantity.Text;
        }

        private void StrengthSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                strengthLabel.Text = "* Strength";
                preStrength.IsEnabled = true;
                preStrengthUnits.IsEnabled = true;
            }
            else
            {
                strengthLabel.Text = "Not Available";
                preStrength.IsEnabled = false;
                preStrengthUnits.IsEnabled = false;
                preStrength.Text = "";
            }
        }
    }
}