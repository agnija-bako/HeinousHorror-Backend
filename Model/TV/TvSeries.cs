using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model.TV
{
    public class TvSeries:Movies
    {
        public string Backdrop_path { get; set; }
        public string First_air_date { get; set; }
        public string Name { get; set; }
        public List<string> Origin_country { get; set; }
        public string Original_language { get; set; }
        public string Original_name { get; set; }
    }
}
