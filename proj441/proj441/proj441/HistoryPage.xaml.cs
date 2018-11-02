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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}
                
        private async void LogDosageButton2_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await Navigation.PushAsync(new LogPage());
        }
    }
}