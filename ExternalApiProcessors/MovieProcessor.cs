using System;
using System.Threading.Tasks;
using System.Net.Http;
using heinousHorror.Model;

namespace heinousHorror.ExternalApiProcessors
{
    public class MovieProcessor
    {
        public static async Task<MovieDB> LoadMovies(string path)
        {
            const string baseUrl = "https://api.themoviedb.org/3/";
            const string fragment = "&language=en-US&page=1&with_genres=27";
            var url = baseUrl + path + fragment;
            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url).ConfigureAwait(false);
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception(response.ReasonPhrase);

                return await response.Content.ReadAsAsync<MovieDB>();
            }
        }

        public static async Task<MovieDetails> LoadMovieDetails(string path)
        {
            const string baseUrl = "https://api.themoviedb.org/3/";
            const string fragment = "&language=en-US";
            var url = baseUrl + path + fragment;
            using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            return await response.Content.ReadAsAsync<MovieDetails>();
        }
    }
}