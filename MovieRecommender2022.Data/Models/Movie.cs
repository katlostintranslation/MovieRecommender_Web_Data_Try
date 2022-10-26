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
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public GenreEnum Genre { get; set; }

        public List<Keyword> Keywords { get; set; } = new List<Keyword>();

        public int Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}\n{Genre}";
        }
    }
}
