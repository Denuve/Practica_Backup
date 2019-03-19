using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wpf_Trivia
{
    class DataProcessor
    {
        public static async Task<JObject> LoadData()
        {
            string url = "https://opentdb.com/api.php?amount=10";

            using (HttpResponseMessage response = await HttpApi.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    JObject data = await response.Content.ReadAsAsync<JObject>();

                    return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
