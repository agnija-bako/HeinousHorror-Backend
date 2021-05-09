using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using heinousHorror.ExternalApiProcessors;
using heinousHorror.Model.Game;
using heinousHorror.Helper;

namespace heinousHorror.Controllers
{
    [ApiController]
    public class GamesController
    {
        [Route("api/games/discover")]
        [HttpGet]
        public async Task<List<Games>> GetAllGames()
        {
            return await GameProcessor.LoadGames("fields *; limit 500; where themes = 19;").ConfigureAwait(false);
        }

        [Route("api/games/popular")]
        [HttpGet]
        public async Task<List<Games>> GetPopularGames()
        {
            return await GameProcessor
                .LoadGames("fields *; limit 20; where themes = 19 & follows != null;sort follows desc;")
                .ConfigureAwait(false);
        }

        [Route("api/games/upcoming")]
        [HttpGet]
        public async Task<List<Games>> GetUpcomingGames()
        {
            DateTime weekAgo = DateTime.Today.AddDays(-7);
            long weekAgoUnix = DateToUnix.GetUnixTime(weekAgo);
            return await GameProcessor
                .LoadGames("fields *; limit 500; where themes = 19 & first_release_date >" + weekAgoUnix +
                           "; sort first_release_date asc;").ConfigureAwait(false);
        }

        [Route("api/games/latest")]
        [HttpGet]
        public async Task<List<Games>> GetLatestGames()
        {
            DateTime today = DateTime.Today;
            long todayUnix = DateToUnix.GetUnixTime(today);
            return await GameProcessor
                .LoadGames("fields *; limit 20; where themes = 19 & first_release_date < " + todayUnix +
                           "; sort first_release_date desc;").ConfigureAwait(false);
        }

        [Route("api/games/top")]
        [HttpGet]
        public async Task<List<Games>> GetTopGames()
        {
            const string query = "fields *; limit 100; where themes = 19 & rating != null; sort rating desc;";
            return await GameProcessor.LoadGames(query).ConfigureAwait(false);
        }

        [Route("api/games/{id}")]
        [HttpGet]
        public async Task<List<Games>> GetGameById(int? id)
        {
            if (id == null)
                return null;

            int gameId = (int) id;
            string query = "fields *; where id =" + gameId + ";";
            return await GameProcessor.LoadGames(query).ConfigureAwait(false);
        }

        [Route("api/games/covers/{id}")]
        [HttpGet]
        public async Task<List<Cover>> GetGameCoverById(int? id)
        {
            if (id == null)
                return null;

            int coverId = (int)id;
            string query = "fields *; where game =" + coverId + ";";
            return await GameProcessor.LoadCover(query).ConfigureAwait(false);
        }
    }
}