using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using heinousHorror.Model.TV;
using heinousHorror.Model;

namespace heinousHorror.ExternalApiProcessors
{
    public class TvProcessor
    {
        public static async Task<Tvdb> LoadTv(string path)
        {
            const string baseUrl = "https://api.themoviedb.org/3/";
            const string fragment = "&language=en-US&page=1&with_genres=27";
            var url = baseUrl + path + fragment;
            using var response = await ApiHelper.ApiClient.GetAsync(url).ConfigureAwait(false);
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.ReasonPhrase);

                }
                return await response.Content.ReadAsAsync<Tvdb>();
            }
        }

        
        public static async Task<TvDetails> LoadTvDetails(string path)
        {
            const string baseUrl = "https://api.themoviedb.org/3/";
            const string fragment = "&language=en-US";
            var url = baseUrl + path  + fragment;
            using var response = await ApiHelper.ApiClient.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);

            }
            return await response.Content.ReadAsAsync<TvDetails>();
        }


    }
}
