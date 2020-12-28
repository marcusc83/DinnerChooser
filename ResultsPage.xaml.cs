using DinnerChooser.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using DinnerChooser.Helper;

namespace DinnerChooser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public IList<BuisnessModel.Result> Places;
        private static string detailQuery = "https://maps.googleapis.com/maps/api/place/details/json?place_id={0}&fields=name,formatted_address,formatted_phone_number,website&key=AIzaSyCAsDXnzTL5XRtnTrFXot38Gt-LRFuF_z4";


        public ResultsPage(ObservableCollection<BuisnessModel.Result> places)
        {
            InitializeComponent();
            Places = new List<BuisnessModel.Result>();
            Places = places;

            ListViewPlaces.ItemsSource = places;
            LabelPlacesCount.Text = LabelPlacesCount.Text + places.Count();
        }

        private void ButtonRandomSelector_Clicked(object sender, System.EventArgs e)
        {
            Random randomNum = new Random();
            int max = Places.Count();
            int x = randomNum.Next(0, max);

            LabelRandomSelection.Text = Places[x].ToString();
        }
        static async Task<BuisnessDetail.Root> DetailQuery(string query, string nextPageToken)
        {
            var pageToken = nextPageToken != null ? "&pagetoken=" + nextPageToken : null;
            var requestUrl = query + pageToken;
            try
            {
                var restClient = new RestClient<BuisnessDetail.Root>();
                var result = await restClient.GetAsync(requestUrl);
                return result;
            }
            catch (Exception e)
            {
                Debug.Write("Error; " + e.Message);
                return null;
            }
        }

        public void ListViewPlaces_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var place = ((ListView)sender);
                string newDetailQuery = string.Format(detailQuery, place);
            }
            catch(Exception ex)
            {
                Debug.Write("Error: " + ex.Message);
            }
        }
    }
}