using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model.Game
{
    public class Cover
    {
        public bool AlphaChannel { get; set; }
        public bool Animated { get;set; }
        public int Game { get; set; }
        public int Height { get; set; }
        public int ImageId { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }

    }
}
