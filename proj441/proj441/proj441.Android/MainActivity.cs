using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ButtonCircle.FormsPlugin.Droid;

namespace proj441.Droid
{
    [Activity(Label = "Pill-Boy", Icon = "@mipmap/pillicon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ButtonCircleRenderer.Init();
            LoadApplication(new App());
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#D32F2F"));  //changes top color  
        }
    }
}