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
            FillPickers();
            BindingContext = p;
            originalPID = p.PID;
            
        }

        private void FillPickers()
        {
            preStrengthUnits.Items.Add("mg");
            preStrengthUnits.Items.Add("mcg");
            preStrengthUnits.Items.Add(" ");
            //preStrengthUnits.SelectedItem = preStrengthUnits.Items.FirstOrDefault();
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

        private async void BackToPrescriptionButton_Clicked(object sender, EventArgs e)
        {
            bool valid = ValidateFields();

            if (!valid)
            {
                await DisplayAlert("Error:", "Please enter values for Required (*) fields", "OK");
            }

            else
            {

                //bool exists = App.MyPrescrpitions.Any(i => i.ProperName == preName.Text.ToUpper() && i.Strength == preStrength.Text && i.StrengthUnits == preStrengthUnits.SelectedItem.ToString());    //Here comes Linq https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=netframework-4.7.2

                //if (exists)
                //{
                //    await DisplayAlert("Error:", "Prescription already exists", "OK");
                //}

                //else
                //{
                    if (StrengthSwitch.IsToggled)
                    {
                        Prescription pUpdated = new Prescription
                        {
                            PID = originalPID,
                            Name = preName.Text.Trim(),
                            ProperName = preName.Text.Trim().ToUpper(),
                            Strength = preStrength.Text.Trim(),
                            StrengthUnits = preStrengthUnits.SelectedItem.ToString(),
                            PrescribedDosage = Convert.ToDouble(preDosage.Text),
                            Instructions = preInstructions.Text.Trim(),
                            PhysicalDescription = preDescription.Text.Trim(),
                            Quantity = Convert.ToDouble(preQuantity.Text.Trim()),
                            Remaining = Convert.ToDouble(preRemaining.Text.Trim())
                        };

                        await App.MyPrescriptionDatabase.SaveItemAsync(pUpdated);
                        await Navigation.PopModalAsync();
                    }

                    else
                    {
                        Prescription pUpdated = new Prescription
                        {
                            PID = originalPID,
                            Name = preName.Text.Trim(),
                            ProperName = preName.Text.Trim().ToUpper(),
                            Strength = " ",
                            StrengthUnits = " ",
                            PrescribedDosage = Convert.ToDouble(preDosage.Text),
                            Instructions = preInstructions.Text.Trim(),
                            PhysicalDescription = preDescription.Text.Trim(),
                            Quantity = Convert.ToDouble(preQuantity.Text.Trim()),
                            Remaining = Convert.ToDouble(preRemaining.Text.Trim())
                        };

                        await App.MyPrescriptionDatabase.SaveItemAsync(pUpdated);
                        await Navigation.PopModalAsync();
                    }
                //}
            }
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
                preStrengthUnits.SelectedItem = "mg";
            }
            else
            {
                strengthLabel.Text = "Not Available";
                preStrength.IsEnabled = false;
                preStrengthUnits.IsEnabled = false;
                preStrength.Text = "";
                preStrengthUnits.SelectedItem =" ";
            }
        }

        private void PreRemaining_Completed(object sender, EventArgs e)
        {
            try
            {
                double q = Convert.ToDouble(preQuantity.Text);
                double r = Convert.ToDouble(preRemaining.Text);
                if (r > q)
                {
                    preRemaining.Text = preQuantity.Text;
                }
            }
            catch
            {
                double q = 0;
                double r = 0;
                if (r > q)
                {
                    preRemaining.Text = preQuantity.Text;
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}