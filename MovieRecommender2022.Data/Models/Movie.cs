using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender2022.Data.Models
{
    public class Movie
    {
        //[Key]
        //public int Rating { get; set; }
       
        //public string Title { get; set; }
        //[Required]
        //[MaxLength(50)]
        //public string Genre { get; set; }


        public Movie(string title)
        {
            Title = title;
        }

        public Movie()
        {
        }

        public string Title { get; set; }

        public GenreEnum Genre { get; set; }

        public string[] Keywords { get; set; }

        public int Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}\n{Genre}";
        }
    }
}
