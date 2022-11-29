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
    }

}