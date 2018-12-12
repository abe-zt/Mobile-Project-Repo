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
	public partial class AddReminderPage : ContentPage
	{
        Prescription p_copy = new Prescription();

        public AddReminderPage ()
		{
			InitializeComponent ();
		}

        public AddReminderPage(Prescription p)
        {
            InitializeComponent();
            BindingContext = p;
            CopyPrescription(p_copy, p);
        }

        public void CopyPrescription(Prescription originalP, Prescription copyP)
        {
            originalP.PID = copyP.PID;
            originalP.Name = copyP.Name;
            originalP.ProperName = copyP.ProperName;
            originalP.Strength = copyP.Strength;
            originalP.StrengthUnits = copyP.StrengthUnits;
            originalP.Instructions = copyP.Instructions;
            originalP.PrescribedDosage = copyP.PrescribedDosage;
            originalP.PhysicalDescription = copyP.PhysicalDescription;
            originalP.Quantity = copyP.Quantity;
            originalP.Remaining = copyP.Remaining;
        }

    }
}