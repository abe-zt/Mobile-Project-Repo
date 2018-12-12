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
	public partial class ReminderPage : ContentPage
	{
		public ReminderPage ()
		{
			InitializeComponent ();
		}

        private async void SetReminderButton2_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Navigation.InsertPageBefore(new SetReminderPage(), this);
            await Navigation.PopAsync();
        }
    }
}