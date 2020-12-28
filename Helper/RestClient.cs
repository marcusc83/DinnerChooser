using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DinnerChooser.Helper
{
    class RestClient <T>
    {
        public async Task<T> GetAsync(string WebServiceURL)
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(WebServiceURL);
                var taskModels = JsonConvert.DeserializeObject<T>(json);
                return taskModels;
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error: " + e.Message);
                return default(T);
            }
        }
    }
}
