using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using WorkDemoAPI.Models;

namespace WorkDemoAPI.Data
{
    public static class SQLHelper
    {
        public static string GetConnection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static List<Movie> ToMovieList(SqlDataReader reader)
        {
            var list = new List<Movie>();
            while (reader.Read())
            {
                var movie = new Movie();
                movie.ID = int.Parse(reader["ID"].ToString());
                movie.Title = reader["Title"].ToString();
                movie.Release = DateTime.Parse(reader["Release"].ToString());
                movie.Runtime = reader["Runtime"].ToString();
                movie.Director = reader["Director"].ToString();
                movie.Actors = reader["Actors"].ToString();
                movie.Genre = reader["Genre"].ToString();
                movie.Rating = float.Parse(reader["Rating"].ToString());
                list.Add(movie);
            }
            return list;
        }
    }
}