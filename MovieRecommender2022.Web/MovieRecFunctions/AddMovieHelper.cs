using MovieRecommender2022.Data;
using MovieRecommender2022.Data.Models;

namespace MovieRecommender2022.Web.MovieRecFunctions
{
    internal static class AddMovieHelper //we will not initiate it
    {
        internal static void Start(MovieList movieList)
        {
            Console.WriteLine("Please enter title of a movie: ");
            var title = Console.ReadLine();

            Console.WriteLine("Please enter genre (Action, Adventure, Comedy, Drama, Fantasy, Horror, Musicals, Mystery, Romance, ScienceFiction, Sports, Thriller, Western): "); //write a method with while loop, similar to Authors
            var genre = Console.ReadLine();

            Console.WriteLine("Please enter rating: "); //make a method with a while, similar to Authors
            var rating = Console.ReadLine();

            var keywords = GetKeywords(); //we are calling the method

            var movie = new Movie(title)
            {
                Genre = (GenreEnum)Enum.Parse(typeof(GenreEnum), genre), //which one we would like to cast (typeof(GenreEnum), then it understands which one it is (genre) 
                Rating = int.Parse(rating), //validation?
                Keywords = keywords
            };

            movieList.Add(movie); //adding to the list
        }

        private static string[] GetKeywords()
        {
            var keywords = new List<string>();

            Console.WriteLine("Please add some keywords");
            Console.WriteLine(Menu.Dash);

            while (true) //we will not know how many keywords, so we need a loop
            {
                Console.Write("Please enter keyword: ");
                var keyword = Console.ReadLine();

                if (!string.IsNullOrEmpty(keyword))
                {
                    keywords.Add(keyword);
                }

                Console.WriteLine("Would you like to add one more keyword [Y/N]?");

                var res = Console.ReadLine();

                if (res.ToUpper() == "N")
                {
                    return keywords.ToArray();
                }
            }
        }
    }
}
