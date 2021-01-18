using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model
{
    public class Movies
    {
        public string Poster_path { get; set; }
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
