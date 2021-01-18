using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heinousHorror.Model.TV
{
    public class TvDetails:TvSeries
    {
        public List<CreatedBy> Created_by { get; set; }
        public List<int> Episode_run_time { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public bool In_production { get; set; }
        public List<string> Languages { get; set; }
        public string Last_air_date { get; set; }
        public LastEpisodeToAir Last_episode_to_air { get; set; }
        public object Next_episode_to_air { get; set; }
        public List<Network> Networks { get; set; }
        public int Number_of_episodes { get; set; }
        public int Number_of_seasons { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<ProductionCountry> Production_countries { get; set; }
        public List<Season> Seasons { get; set; }
        public List<SpokenLanguage> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Type { get; set; }
    }
}
public class CreatedBy
{
    public int Id { get; set; }
    public string Credit_id { get; set; }
    public string Name { get; set; }
    public int Gender { get; set; }
    public string Profile_path { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class LastEpisodeToAir
{
    public string Air_date { get; set; }
    public int Episode_number { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Overview { get; set; }
    public string Production_code { get; set; }
    public int Season_number { get; set; }
    public string Still_path { get; set; }
    public double Vote_average { get; set; }
    public int Vote_count { get; set; }
}

public class Network
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Logo_path { get; set; }
    public string Origin_country { get; set; }
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
    public string Iso_3166_1 { get; set; }
    public string Name { get; set; }
}

public class Season
{
    public string Air_date { get; set; }
    public int Episode_count { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Overview { get; set; }
    public string Poster_path { get; set; }
    public int Season_number { get; set; }
}

public class SpokenLanguage
{
    public string English_name { get; set; }
    public string Iso_639_1 { get; set; }
    public string Name { get; set; }
}