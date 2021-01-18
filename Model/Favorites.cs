using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model
{
    public class Favorites
    {
        public int MovieId { get; set; }
        public int TvId { get; set; }
        public int GameId { get; set; }
        public string MoviePosterPath { get; set; }
        public string TvPosterPath { get; set; }
        public int GameCover { get; set; }
        public string MovieTitle { get; set; }
        public string TvTitle { get; set; }
        public string GameTitle { get; set; }
        public double MovieVoteAverage { get; set; }
        public double TvVoteAverage { get; set; }
        public double GameRating { get; set; }
        public int UserId { get; set; }
    }
}
