using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WorkDemoAPI.Models;
using WorkDemoAPI.Data;

namespace WorkDemoAPI.Controllers
{
    public class MoviesController : ApiController
    {
        public MoviesController()
        {   
            Logger.Init($"WorkDemoAPI-{DateTime.Now.Date.ToString("dd-MM-yy")}");
        }

        // GET api/movies
        [Route("api/movies")]
        public IHttpActionResult Get()//IEnumerable<Movie> Get()
        {
            Logger.Write("GET api/movies");
            try
            {
                IEnumerable<Movie> movies = MovieHandler.ReadAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                return InternalServerError(ex);
            }
        }

        // GET api/movies/title/The_Notebook
        [Route("api/movies/title/{title}")]
        public IHttpActionResult Get(string title)
        {
            Logger.Write("GET api/movies/title/{title}");
            try
            {
                IEnumerable<Movie> movies = MovieHandler.ReadByTitle(title);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                return InternalServerError(ex);
            }
        }

        // GET api/movies/year/2004
        [Route("api/movies/year/{year}")]
        public IHttpActionResult Get(int year)
        {
            Logger.Write("GET api/movies/year/{year}");
            try
            {
                IEnumerable<Movie> movies = MovieHandler.ReadByYear(year);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                return InternalServerError(ex);
            }
        }

        // POST api/movies
        [Route("api/movies")]
        public IHttpActionResult Post([FromBody] IEnumerable<Movie> movies)
        {
            Logger.Write("POST api/movies");
            try
            {
                MovieHandler.Insert(movies);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Write(ex.ToString());
                return InternalServerError(ex);
            }
        }
    }
}