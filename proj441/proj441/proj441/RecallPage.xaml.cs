using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using RecallJson;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proj441
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecallPage : ContentPage
    {
        public RecallPage()
        {
            InitializeComponent();
        }

        private async void RecallLookup_Clicked(object sender, EventArgs e)
        {
            bool connection = CrossConnectivity.Current.IsConnected;

            if (connection)
            {
                if (userEntry.Text != null)
                {
                    string d1 = DateTime.Now.ToString("yyyyMMdd");
                    string d2 = DateTime.Now.AddYears(-1).ToString("yyyyMMdd");

                    string userString = userEntry.Text;

                    //userString = userString.ToLower();

                    HttpClient client = new HttpClient();
                    string dictionaryEndpoint = "https://api.fda.gov/drug/enforcement.json?search=report_date:[" + d2 + "+TO+" + d1 + "]+AND+city:" + userString + "+AND+status:ongoing&limit=100";
                    Uri dictionaryUri = new Uri(dictionaryEndpoint);
                    HttpResponseMessage response = await client.GetAsync(dictionaryEndpoint);

                    if (response.IsSuccessStatusCode)
                    {

                        string jsonString = await response.Content.ReadAsStringAsync();
                        var myRecalls = MyRecalls.FromJson(jsonString);

                        //List<Define> myDefinitions = JsonConvert.DeserializeObject<List<Define>>(jsonContent);

                        if (myRecalls.Meta.Results.Total > 0)
                        {
                            ObservableCollection<Result> myRecallsCollection = new ObservableCollection<Result>();

                            myRecalls.Results.ForEach(myRecallsCollection.Add);


                            RecallsListView.ItemsSource = myRecallsCollection;
                            RecallsListView.IsVisible = true;
                            userLabel.IsVisible = false;
                        }

                        else
                        {
                            userLabel.Text = "NO RECALLS IN YOUR CITY WITHIN LAST YEAR";    //strings of letters that are not words, but still return success
                            RecallsListView.IsVisible = false;
                        }
                    }
                    else
                    {
                        userLabel.Text = "NO ENTRIES/NO RECALLS IN YOUR CITY WITHIN LAST YEAR";    //for empty strings
                        RecallsListView.IsVisible = false;
                    }
                }
                else
                {
                    userLabel.Text = "PLEASE ENTER A CITY NAME";    //for dealing with strings containing illegal characters (including spaces that does not return a success response)
                }
            }
            else
            {
                await DisplayAlert("No Internet", "No Internet Connection Detected", "OK");
                RecallsListView.IsVisible = false;
            }
        }

        protected override void OnAppearing()
        {
           
        }
    }
}