using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model.TV
{
    public class Tvdb
    {
        public int Page { get; set; }
        public List<TvSeries> Results { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
    }
}
