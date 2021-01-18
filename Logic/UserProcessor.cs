using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using heinousHorror.DataAccess;
using heinousHorror.Helper;
using heinousHorror.Model;
using heinousHorror.Model.Game;
using heinousHorror.Model.TV;

namespace heinousHorror.Logic
{
    public static class UserProcessor
    {
        public static int CreateUser(string name, string email, string password, string salt)
        {
            var data = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Salt = salt
            };
            var sql = $"INSERT INTO users (name, email, password, password_salt) VALUES (@name, @email, @password, @salt);";
            return SqlDataAccess.SaveData<string>(sql, data);
        }

        public static int CreateFavoriteMovie(int id, string posterPath, string originalTitle, double voteAverage,
            int userId)
        {
            var data = new Movies
            {
                Id = id,
                Poster_path = posterPath,
                Original_title = originalTitle,
                Vote_average = voteAverage
            };
            var sql =
                $"INSERT INTO movies (external_id, poster_path, original_title, vote_average, user_id) " +
                $"VALUES (@id, @posterPath, @title, @voteAverage, @userId);";
            return SqlDataAccess.SaveFavoriteMovie<string>(sql, data, userId);

        }

        public static int CreateFavoriteTv(int id, string posterPath, string originalName, double voteAverage,
            int userId)
        {
            var data = new TvSeries
            {
                Id = id,
                Poster_path = posterPath,
                Original_name = originalName,
                Vote_average = voteAverage
            };
            var sql =
                $"INSERT INTO tv (external_id, poster_path, original_name, vote_average, user_id) " +
                $"VALUES (@id, @posterPath, @title, @voteAverage, @userId);";
            return SqlDataAccess.SaveFavoriteTv<string>(sql, data, userId);

        }

        public static int CreateFavoriteGame(int id, int cover, string name, double totalVote,
            int userId)
        {
            var data = new Games
            {
                Id = id,
                Cover = cover,
                Name = name,
                Total_rating = totalVote
            };
            var sql =
                $"INSERT INTO games (external_id, cover, name, total_rating, user_id) " +
                $"VALUES (@id, @cover, @name, @totalRating, @userId);";
            return SqlDataAccess.SaveFavoriteGame<string>(sql, data, userId);

        }

        public static User GetUser(int id)
        {
            var sql = $"SELECT * FROM users WHERE id = @userId;";
            
            return SqlDataAccess.LoadData<string>(sql, id);
        }

        public static Favorites GetFavorites(int id)
        {
            var sql = $"SELECT * FROM(SELECT movies.external_id AS movie_id, tv.external_id AS tv_id, " +
                      $"games.external_id AS game_id, movies.poster_path AS movie_poster_path, tv.poster_path AS tv_poster_path," +
                      $"games.cover, original_title, original_name, name, movies.vote_average, tv.vote_average, total_rating, movies.user_id " +
                      $"FROM movies " +
                      $"JOIN tv ON tv.user_id = movies.user_id " +
                      $"JOIN games ON games.user_id = movies.user_id) AS favorites " +
                      $"WHERE favorites.user_id = @userId;";

            return SqlDataAccess.LoadFavorite<string>(sql, id);
        }

        public static User GetUserByName(string name)
        {
            var sql = $"SELECT password, password_salt FROM users WHERE name = @name;";
            return SqlDataAccess.LoadUser<string>(sql, name);
        }
    }
}
