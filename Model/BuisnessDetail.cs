﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DinnerChooser.Model
{
    class BuisnessDetail
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Review
        {
            public string author_name { get; set; }
            public string author_url { get; set; }
            public string language { get; set; }
            public string profile_photo_url { get; set; }
            public int rating { get; set; }
            public string relative_time_description { get; set; }
            public string text { get; set; }
            public int time { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string adr_address { get; set; }
            public string formatted_address { get; set; }
            public string formatted_phone_number { get; set; }
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string international_phone_number { get; set; }
            public string name { get; set; }
            public string place_id { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public List<Review> reviews { get; set; }
            public List<string> types { get; set; }
            public string url { get; set; }
            public int utc_offset { get; set; }
            public string vicinity { get; set; }
            public string website { get; set; }
        }

        public class Root
        {
            public List<object> html_attributions { get; set; }
            public Result result { get; set; }
            public string status { get; set; }
        }


    }
}
