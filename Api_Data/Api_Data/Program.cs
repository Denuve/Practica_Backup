using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Api_Data
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<string> GetProductAsync(string path)
        {
            var data = "";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }

        static async Task MyTaskAsync()
        {
            string path = "https://randomuser.me/api/";
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var data = await GetProductAsync(path);



            JObject googleSearch = JObject.Parse(data);

            IList<JToken> results = googleSearch["results"].Children().ToList();

            foreach (JToken result in results)
            {
                Console.WriteLine(result["gender"]);
            }
            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            MyTaskAsync().GetAwaiter().GetResult();
        }
    }
}
