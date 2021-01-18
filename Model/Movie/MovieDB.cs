using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model
{
    public class MovieDB
    {
        public int Page { get; set; }
        public List<Movies> Results { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
    }
}
