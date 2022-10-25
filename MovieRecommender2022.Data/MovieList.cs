using MovieRecommender2022.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender2022.Data
{
    public class MovieList
    {
        public MovieList()
        {
            Load(); //will be called when we create Movielist
        }

        public MovieList(string url)
        {
            Load(url); //with url argument
        }

        private List<Movie> _movies = new List<Movie>(); //we initialize it empty, otherwise value will be null

        public List<Movie> Movies { get { return _movies; } } //added get access to movie list for search and delete
        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public void Delete(Movie movie)
        {
            _movies.Remove(movie);
        }

        public IEnumerable<Movie> SearchTitle(string query)
        {
            return _movies.Where(b => b.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase)); //We are looking for movies, where title contains query we entered on a webpage
        }
        public IEnumerable<Movie> SearchGenre(GenreEnum genre)
        {
            return _movies.Where(b => b.Genre == genre);
        }

        public IEnumerable<Movie> SearchKeyword(string query, IEnumerable<Movie> movies)
        {
            return _movies.Where(x => x.Keywords.Any(z => z.Contains(query, StringComparison.InvariantCultureIgnoreCase))); //we are looking with Any
        }

        //public IEnumerable<Movie> Search(string query) //signature, by which criteria we will find a movie. IEnumerable - validation that you cannot change directly the list of movies. Istrinti visa metoda
        //{
        //    return _movies.Where(x => x.Title.Contains(query, StringComparison.InvariantCultureIgnoreCase));
        //    //return new List<Movie>();
        //}

        //private void Load()
        //{
        //    _movies.Add(new Movie("Avatar") //reikes istrinti
        //    {
        //        Rating = 5,
        //        Genre = GenreEnum.Fantasy,
        //        Keywords = new string[] { "blue people", "spaceship", "alien" }
        //    });

        //    _movies.Add(new Movie("Avatar 2") //reikes istrinti
        //    {
        //        Rating = 4,
        //        Genre = GenreEnum.Fantasy,
        //        Keywords = new string[] { "blue people", "spaceship", "alien" }
        //    });
        //}

        private void Load() //without arguments
        {
            _movies = XmlMovieHelper.Load();
        }

        private void Load(string url)
        {
            _movies = XmlMovieHelper.Load(url); //we read from url
        }
    }
}
