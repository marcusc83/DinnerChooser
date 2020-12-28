using DinnerChooser.Helper;
using DinnerChooser.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DinnerChooser
{
    public partial class MainPage : ContentPage
    {
        string food;
        double distance;
        double lattitude;
        double longitude;
        CancellationTokenSource cts;
        private static string apiKey = "AIzaSyCAsDXnzTL5XRtnTrFXot38Gt-LRFuF_z4";
        private static string nearbyQuery = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=";

        public MainPage()
        {
            InitializeComponent();
            getCurrentLocation();
        }
        private void RecentChoicePageActivated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecentChoicesPage());
        }
        private async void FindFoodClicked(object sender, EventArgs e)
        {
            try
            {
                string query = getQuery(nearbyQuery);
                var result = await NearbySerchQuery(query,"");

                var resultList = new ObservableCollection<BuisnessModel.Result>();
                foreach (var item in result.results) resultList.Add(item);
                await Navigation.PushAsync(new ResultsPage(resultList));
                //labelcount.Text = "total places: " + Places.Count() + "Result: " + resultList.Count() + Places[0].name;
            }
            catch (Exception exp)
            {
                Debug.Write("Error: " + exp.Message);
            }
        }
        public void FoodEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            food = e.NewTextValue;
        }

        public void DistanceEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                distance = Convert.ToDouble(e.NewTextValue);
                double dist = distance * 1609.344;
                distance = Math.Round(dist);
            }

            catch (Exception exp)
            {
                Debug.WriteLine("Error: " + exp.Message);
            }
        }

        public async void getCurrentLocation()
        { 
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    lattitude = location.Latitude;
                    longitude = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.WriteLine("Error: " + fnsEx.Message);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Debug.WriteLine("Error: " + fneEx.Message);
            }
            catch (PermissionException pEx)
            {
                Debug.WriteLine("Error: " + pEx.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        static async Task<BuisnessModel.Root> NearbySerchQuery(string query, string nextPageToken)
        {
            var pageToken = nextPageToken != null ? "&pagetoken=" + nextPageToken : null;
            var requestUrl = query + pageToken;
            try
            {
                var restClient = new RestClient<BuisnessModel.Root>();
                var result = await restClient.GetAsync(requestUrl);
                return result;
            }
            catch (Exception e)
            {
                Debug.Write("Error; " + e.Message);
                return null;
            }
        }
        public String getQuery(string query)
        {
            string Query = query + lattitude.ToString() + "," + longitude.ToString() + "&radius=" + distance.ToString() + "&type=restaurant&keyword=" + food + "&key=" + apiKey;
            return Query;
        }
    }
}
