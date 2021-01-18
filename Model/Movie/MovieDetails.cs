using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model
{
    public class MovieDetails : Movies
    {
        public string Backdrop_path { get; set; }
        public object Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public string Imdb_id { get; set; }
        public string Original_language { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<ProductionCountry> Production_countries { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguage> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Logo_path { get; set; }
        public string Name { get; set; }
        public string Origin_country { get; set; }
    }

    public class ProductionCountry
    {
        public string Iso31661 { get; set; }
        public string Name { get; set; }
    }

    public class SpokenLanguage
    {
        public string English_name { get; set; }
        public string Iso6391 { get; set; }
        public string Name { get; set; }
    }
}
