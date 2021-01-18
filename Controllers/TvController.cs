using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using heinousHorror.Model.TV;
using heinousHorror.ExternalApiProcessors;
using Microsoft.Extensions.Configuration;


namespace heinousHorror.Controllers
{
    [ApiController]
    public class TvController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TvController(IConfiguration config)
        {
            _config = config;
        }

        [Route("api/tv/popular")]
        [HttpGet]
        public async Task<Tvdb> GetPopularTv()
        {
            var path = "tv/popular?api_key=" + _config["MoviesDbKey"];
            var tv = await TvProcessor.LoadTv(path);
            return tv;
        }
        [Route("api/tv/discover")]
        [HttpGet]
        public async Task<Tvdb> GetAllTv()
        {
            var path = "discover/tv?api_key="+ _config["MoviesDbKey"] + "&sort_by=popularity.desc&page=1";
            var tv = await TvProcessor.LoadTv(path);
            return tv;

        }
        [Route("api/tv/top")]
        [HttpGet]
        public async Task<Tvdb> GetTopTv()
        {
            var path = "tv/top_rated?api_key=" + _config["MoviesDbKey"];
            var tv = await TvProcessor.LoadTv(path);
            return tv;

        }
        [Route("api/tv/{id?}")]
        [HttpGet]
        public async Task<TvDetails> GetMovieDetails(int? id)
        {
            if (id == null)
                return null;

            var tvId = (int)id;
            var path = "tv/" + tvId + "?api_key=" + _config["MoviesDbKey"];
            var tv = await TvProcessor.LoadTvDetails(path);
            return tv;
        }

    }
}
