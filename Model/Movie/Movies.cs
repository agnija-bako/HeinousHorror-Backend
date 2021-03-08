using System.Collections.Generic;

namespace heinousHorror.Model
{
    public class Movies
    {
        private const string BaseUrl = "https://image.tmdb.org/t/p/w500";
        private string _posterPath;

        public string Poster_path
        {
            get => $"{BaseUrl}{_posterPath}";
            set => _posterPath = value;
        }

        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public List<int> Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_title { get; set; }
        public double Popularity { get; set; }
        public int Vote_count { get; set; }
        public double Vote_average { get; set; }
    }
}