using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using heinousHorror.Model;
using System.Net.Http;
using System.Web;
using heinousHorror.Model.Game;
using Newtonsoft.Json;

namespace heinousHorror.ExternalApiProcessors
{
    public static class GameProcessor
    {
        public static GameAuth GameApiData { get; set; }
        public static string ClientId { get; set; }
        
        public static async Task AuthenticateGameApi()
        {
            ClientId = Startup.StaticConfiguration["GameDbClientId"];

            var builder = new UriBuilder("https://id.twitch.tv/oauth2/token");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["client_id"] = ClientId;
            query["client_secret"] = Startup.StaticConfiguration["GamesDbClientSecret"];
            query["grant_type"] = "client_credentials";
            builder.Query = query.ToString() ?? string.Empty;
            var url = builder.ToString();

            using var response = await ApiHelper.ApiClient.PostAsync(url, null).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                GameApiData = await response.Content.ReadAsAsync<GameAuth>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<List<Games>> LoadGames(string query)
        {
            string url = "https://api.igdb.com/v4/games";
            var postContent = new StringContent(query);
            using HttpResponseMessage response =
                await ApiHelper.GameApiClient.PostAsync(url, postContent).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<Games>>();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}