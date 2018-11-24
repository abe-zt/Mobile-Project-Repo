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
            var detailPage = ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).CurrentPage;  //get the current masterdetailpage Detail page 
            
            if (item != null &&  detailPage.Title != item.Title && item.Title != "Log Out" )  //don't do anything on the logout cell is pressed
            {
                Detail =  new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) { BarBackgroundColor=Color.FromHex("#D32F2F") };
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
            else if(item != null)  //don't do anything on the logout cell is pressed
            {
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
