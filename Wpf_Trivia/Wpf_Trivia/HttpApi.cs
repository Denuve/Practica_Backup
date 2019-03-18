using System.Net.Http;
using System.Net.Http.Headers;

namespace Wpf_Trivia
{
    public static class HttpApi
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue
                                                      ("aplication/json"));
        }
    }
}
