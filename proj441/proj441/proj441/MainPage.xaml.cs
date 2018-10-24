using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proj441
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);  //THIS IS THE IDEAL LOCATION (underneath InitializeComponent)
            masterPage.listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null && item.Title != "Log Out" )
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) { BarBackgroundColor=Color.FromHex("#D32F2F") };
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
            else if(item != null && item.Title == "Log Out")
            {

            }
        }
    }
}
