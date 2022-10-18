using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WorkDemoAPI.Models;

namespace WorkDemoAPI.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/movies
        [Route("api/movies")]
        public IEnumerable<Movie> Get()
        {
            return MovieModel.ReadAll();
        }

        // GET api/movies/title/The_Notebook
        [Route("api/movies/title/{title}")]
        public IEnumerable<Movie> Get(string title)
        {
            return MovieModel.ReadByTitle(title);
        }

        // GET api/movies/year/2004
        [Route("api/movies/year/{year}")]
        public IEnumerable<Movie> Get(int year)
        {
            return MovieModel.ReadByYear(year);
        }
        // POST api/movies
        [Route("api/movies")]
        public void Post([FromBody] IEnumerable<Movie> movies)
        {
            MovieModel.Insert(movies);
        }
    }
}