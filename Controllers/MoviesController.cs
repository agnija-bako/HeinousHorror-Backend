using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using heinousHorror.Model;
using heinousHorror.ExternalApiProcessors;
using Microsoft.Extensions.Configuration;

namespace heinousHorror.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static IConfiguration Config => Startup.StaticConfiguration;

        [Route("api/movies/popular")]
        [HttpGet]
        public async Task<MovieDB> GetPopularMovies()
        {
            
            var path = "movie/popular?api_key=" + Config["MoviesDbKey"];
            var movies = await MovieProcessor.LoadMovies(path);
            return movies;
        }

        [Route("api/movies/discover")]
        [HttpGet]
        public async Task<MovieDB> GetAllMovies()
        {
            var path = "discover/movie?api_key=" + Config["MoviesDbKey"];
            var movies = await MovieProcessor.LoadMovies(path);
            return movies;
        }

        [Route("api/movies/upcoming")]
        [HttpGet]
        public async Task<MovieDB> GetUpcomingMovies()
        {
            var path = "movie/upcoming?api_key=" + Config["MoviesDbKey"];
            MovieDB movies = await MovieProcessor.LoadMovies(path);
            return movies;
        }
        [Route("api/movies/top")]
        [HttpGet]
        public async Task<MovieDB> GetTopMovies()
        {
            var path = "movie/top_rated?api_key=" + Config["MoviesDbKey"];
            MovieDB movies = await MovieProcessor.LoadMovies(path);
            return movies;
        }
        [Route("api/movies/playing_now")]
        [HttpGet]
        public async Task<MovieDB> GetPlayingNowMovies()
        {
            var path = "movie/now_playing?api_key=" + Config["MoviesDbKey"];
            MovieDB movies = await MovieProcessor.LoadMovies(path);
            return movies;
        }

        [Route("api/movies/{id?}")]
        [HttpGet]
        public async Task<MovieDetails> GetMovieDetails(int? id)
        {
            if (id == null)
                return null;

            var movieId = (int) id;
            var path = "movie/" + movieId +
                       "?api_key=" + Config["MoviesDbKey"];
            MovieDetails movie = await MovieProcessor.LoadMovieDetails(path);
            return movie;
        }

    }
}
