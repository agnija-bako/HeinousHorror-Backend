using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model.Game
{
    public class Games
    {
        public int Id { get; set; }
        public double Aggregated_rating { get; set; }
        public int Aggregated_rating_count { get; set; }
        public int Category { get; set; }
        public int Cover { get; set; }
        public int Created_at { get; set; }
        public List<int> External_games { get; set; }
        public int First_release_date { get; set; }
        public int Follows { get; set; }
        public List<int> Game_modes { get; set; }
        public List<int> Genres { get; set; }
        public List<int> Involved_companies { get; set; }
        public List<int> Keywords { get; set; }
        public string Name { get; set; }
        public List<int> Platforms { get; set; }
        public List<int> Player_perspectives { get; set; }
        public double Rating { get; set; }
        public int Rating_count { get; set; }
        public List<int> Release_dates { get; set; }
        public List<int> Screenshots { get; set; }
        public List<int> Similar_games { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public List<int> Tags { get; set; }
        public List<int> Themes { get; set; }
        public double Total_rating { get; set; }
        public int Total_rating_count { get; set; }
        public int Updated_at { get; set; }
        public string Url { get; set; }
        public List<int> Videos { get; set; }
        public List<int> Websites { get; set; }
        public string Checksum { get; set; }
    }
}
