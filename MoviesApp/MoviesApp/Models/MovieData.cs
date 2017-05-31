using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MovieData
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<Movie> movies { get; set; }
    }

    public class Movie
    {
        public string title { get; set; }
        public string releaseYear { get; set; }
    }
}
