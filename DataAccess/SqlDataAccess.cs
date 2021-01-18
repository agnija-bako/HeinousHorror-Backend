using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using heinousHorror.Model;
using heinousHorror.Model.Game;
using heinousHorror.Model.TV;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace heinousHorror.DataAccess
{
    public class SqlDataAccess
    {
        public static User LoadData<T>(string sql, int id)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("userId", id);
                using var reader = cmd.ExecuteReader();
                var user = new User();
                while (reader.Read())
                {
                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Email = reader.GetString(2);
                }

                return user;
            }
        }

        public static User LoadUser<T>(string sql, string name)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("name", name);
                using var reader = cmd.ExecuteReader();
                var user = new User();
                while (reader.Read())
                {
                    user.Password = reader.GetString(0);
                    user.Salt = reader.GetString(1);
                }

                return user;
            }
        }


        public static Favorites LoadFavorite<T>(string sql, int id)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("userId", id);
                using var reader = cmd.ExecuteReader();
                var favorites = new Favorites();
                while (reader.Read())
                {
                    favorites.MovieId = reader.GetInt32(0);
                    favorites.TvId = reader.GetInt32(1);
                    favorites.GameId = reader.GetInt32(2);
                    favorites.MoviePosterPath = reader.GetString(3);
                    favorites.TvPosterPath = reader.GetString(4);
                    favorites.GameCover = reader.GetInt32(5);
                    favorites.MovieTitle = reader.GetString(6);
                    favorites.TvTitle = reader.GetString(7);
                    favorites.GameTitle = reader.GetString(8);
                    favorites.MovieVoteAverage = reader.GetDouble(9);
                    favorites.TvVoteAverage = reader.GetDouble(10);
                    favorites.GameRating = reader.GetDouble(11);
                    favorites.UserId = reader.GetInt32(12);
                }

                return favorites;
            }
        }


        public static int SaveData<T>(string sql, User data)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("name", data.Name);
                cmd.Parameters.AddWithValue("email", data.Email);
                cmd.Parameters.AddWithValue("password", data.Password);
                cmd.Parameters.AddWithValue("salt", data.Salt);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int SaveFavoriteMovie<T>(string sql, Movies data, int userId)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("id", data.Id);
                cmd.Parameters.AddWithValue("posterPath", data.Poster_path);
                cmd.Parameters.AddWithValue("title", data.Original_title);
                cmd.Parameters.AddWithValue("voteAverage", data.Vote_average);
                cmd.Parameters.AddWithValue("userId", userId);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int SaveFavoriteTv<T>(string sql, TvSeries data, int userId)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("id", data.Id);
                cmd.Parameters.AddWithValue("posterPath", data.Poster_path);
                cmd.Parameters.AddWithValue("title", data.Original_name);
                cmd.Parameters.AddWithValue("voteAverage", data.Vote_average);
                cmd.Parameters.AddWithValue("userId", userId);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int SaveFavoriteGame<T>(string sql, Games data, int userId)
        {
            using var cnn = new NpgsqlConnection(Startup.Db);
            {
                cnn.Open();
                var cmd = new NpgsqlCommand(sql, cnn);
                cmd.Parameters.AddWithValue("id", data.Id);
                cmd.Parameters.AddWithValue("cover", data.Cover);
                cmd.Parameters.AddWithValue("name", data.Name);
                cmd.Parameters.AddWithValue("totalRating", data.Total_rating);
                cmd.Parameters.AddWithValue("userId", userId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}