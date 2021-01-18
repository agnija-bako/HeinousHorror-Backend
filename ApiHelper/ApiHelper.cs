using System.Net.Http;
using System.Net.Http.Headers;
using heinousHorror.ExternalApiProcessors;

namespace heinousHorror.Model
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static HttpClient GameApiClient { get; set; }

        public static void InitializeClients()
        {
            InitializeClient();
            InitializeGameClient();
        }

        public static void InitializeClient()
        {

            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        public static async void InitializeGameClient()
        {
            await GameProcessor.AuthenticateGameApi();
            GameApiClient = new HttpClient();
            GameApiClient.DefaultRequestHeaders.Accept.Clear();
            GameApiClient.DefaultRequestHeaders.Add("Client-ID", GameProcessor.ClientId);
            GameApiClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GameProcessor.GameApiData.Access_token);
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
