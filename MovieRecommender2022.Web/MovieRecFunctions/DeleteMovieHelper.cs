using MovieRecommender2022.Data;
using MovieRecommender2022.Data.Models;

namespace MovieRecommender2022.Web.MovieRecFunctions
{
    internal class DeleteMovieHelper
    {
        internal static void Start(MovieList movieList)
        {
            var movies = movieList.Movies; //introducing local variable
            var selection = GetDeleteSelection(); //we are switching the selection
            switch (selection)
            {
                case "L": //if user wanted a list of movies
                    FindRecommendationHelper.SearchResults(movies);
                    var option = MovieNumberOption();

                    var movie = movies.ElementAt(option - 1); //we find a specific movie

                    if (option <= movies.Count() && GetDeleteConfirmation(movie)) //checks if response is valid
                    {
                        movieList.Delete(movie); //deletes the movie
                        Console.WriteLine("Movie was deleted");
                    }
                    break;
                case "S":
                    while (true)
                    {
                        var searchResults = FindRecommendationHelper.Search(movies); //we use helper to find a movie
                        FindRecommendationHelper.SearchResults(searchResults);
                        if (searchResults.Count() == 1 && GetDeleteConfirmation(searchResults.First()))
                        {
                            movies.Remove(searchResults.First());
                            Console.WriteLine("Movie was deleted");
                            break;
                        }
                    }
                    break;
            }
        }
        private static string GetDeleteSelection() //find movie by the list or by search criteria
        {
            while (true)
            {
                Console.WriteLine(Menu.Dash); //printing a sub menu
                Console.WriteLine("1 - Pick a movie to delete from a list [L]");
                Console.WriteLine("2 - Search for a movie to delete [S]");
                Console.WriteLine(Menu.Dash);

                Console.Write("Select: ");

                var input = Console.ReadLine();

                if (input != null && DeleteValidation(input))
                {
                    return input.ToUpper();
                }
            }
        }

        private static bool DeleteValidation(string userInput) //we are validating user input, if he picks L or S. Combine method with Menu method?
        {
            var validMenuOption = new string[] { "L", "S" };

            return validMenuOption.Contains(userInput.ToUpper());
        }

        private static int MovieNumberOption()
        {
            while (true)
            {
                Console.Write("Enter a number of the movie you would like to delete: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
            }
        }

        private static bool GetDeleteConfirmation(Movie movie) //we are getting do we really want to delete the movie
        {
            while (true)
            {
                Console.WriteLine($"Do you really want to delete movie {movie.Title} [Y/N]?");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Y":
                        return true;
                    case "N":
                        return false;
                    default:
                        break;
                }
            }
        }
        //while (addMovie)
        //{
        //    Console.WriteLine("Please enter movie title, which you want to delete: ");
        //    var movieTitle = Console.ReadLine();

        //    var moviesToDelete = movieList.Search(movieTitle).ToList(); //we are using Search method and converting to List (it is not necesserily to convert to List)
        //    if (moviesToDelete.Count() > 0)
        //    {
        //        foreach (var movie in moviesToDelete) //we are going through list of the movies
        //        {
        //            Console.WriteLine($"Deleting a movie {movie.Title}");
        //            movieList.Delete(movie); //we are giving it a remove method of MovieList
        //        }
        //    }
        //else (we dont need this part)
        //    {
        //        Console.WriteLine("No movies found under this title"); //if we didnt find a movie
        //    }
        //    Console.WriteLine("Would you like to delete another movie? [Y/N]");
        //    var ifDelete = Console.ReadLine().ToUpper();
        //    if (ifDelete != "Y")
        //    {
        //        addMovie = false;
        //    }
        //}
    }
}
