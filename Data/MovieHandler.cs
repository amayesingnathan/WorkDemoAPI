using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WorkDemoAPI.Models;

namespace WorkDemoAPI.Data
{
    public static class MovieHandler
    {
        public static void Insert(IEnumerable<Movie> movies)
        {
            using (var connection = new SqlConnection(SQLHelper.GetConnection("WorkDemoDB")))
            {
                foreach (Movie movie in movies)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.Movies_Insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@Title", movie.Title);
                        cmd.Parameters.AddWithValue("@Release", movie.Release);
                        cmd.Parameters.AddWithValue("@Runtime", movie.Runtime);
                        cmd.Parameters.AddWithValue("@Director", movie.Director);
                        cmd.Parameters.AddWithValue("@Actors", movie.Actors);
                        cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                        cmd.Parameters.AddWithValue("@Rating", movie.Rating);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public static IEnumerable<Movie> ReadByTitle(string title)
        {
            using (var connection = new SqlConnection(SQLHelper.GetConnection("WorkDemoDB")))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Movies_GetByTitle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@Title", title);

                    connection.Open();
                    return SQLHelper.ToMovieList(cmd.ExecuteReader());
                }
            }
        }
        public static IEnumerable<Movie> ReadByYear(int year)
        {
            using (var connection = new SqlConnection(SQLHelper.GetConnection("WorkDemoDB")))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.Movies_GetByYear";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    SqlParameter parameter = cmd.Parameters.Add("@Year", SqlDbType.Date);
                    parameter.Value = new DateTime(year, 1, 1).Date;

                    connection.Open();
                    return SQLHelper.ToMovieList(cmd.ExecuteReader());
                }
            }
        }
        public static IEnumerable<Movie> ReadAll()
        {
            using (var connection = new SqlConnection(SQLHelper.GetConnection("WorkDemoDB")))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Movies";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    connection.Open();
                    List<Movie> results = SQLHelper.ToMovieList(cmd.ExecuteReader());

                    return results;
                }
            }
        }
    }
}