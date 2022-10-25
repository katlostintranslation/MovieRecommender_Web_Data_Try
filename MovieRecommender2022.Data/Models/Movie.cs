using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender2022.Data.Models
{
    public class Movie
    {

        public int Rating { get; set; }
        [Required]
        public string Title { get; set; }   

        public string Genre { get; set; }


        //public Movie(string title)
        //{
        //    Title = title;
        //}

        //public Movie()
        //{
        //}

        //public string Title { get; set; }

        //public GenreEnum Genre { get; set; }

        //public string[] Keywords { get; set; }

        //public int Rating { get; set; }

        //public override string ToString()
        //{
        //    return $"{Title}\n{Genre}";
        //}
    }
}
