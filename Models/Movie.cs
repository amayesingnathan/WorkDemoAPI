using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;

namespace WorkDemoAPI.Models
{
    public class Movie
    {
        public int ID { get; set; } = -1;
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public string Runtime { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public float Rating { get; set; }

        public Movie() { }
        public Movie(int iD, string title, DateTime release, string runtime, string director, string actors, string genre, float rating)
        {
            ID = iD;
            Title = title;
            Release = release;
            Runtime = runtime;
            Director = director;
            Actors = actors;
            Genre = genre;
            Rating = rating;
        }
    }

    public static class MovieHelper
    {
        public static List<Movie> ToList(SqlDataReader reader)
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