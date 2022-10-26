using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieRecommender2022.Data.Models;

namespace MovieRecommender2022.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Movie> Movies { get; set; } = Enumerable.Empty<Movie>(); //our movie list initially would be empty list. We take results and asign to book property

        public string SearchType { get; set; } = "T"; //represents search by title

        public string SelectedGenre { get; set; } = string.Empty;

        public string SearchQuery { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() //this method is called, when our page loads
        {
            var a = "";
        }

        public void OnPost() //we call this method to send data for search. This method will be executed, when we submit form in web
        {
            var query = Request.Form["searchQuery"].ToString(); //we are getting query value
            var searchType = Request.Form["searchType"].ToString();
            var searchTypeSelected = Request.Form["searchTypeSelected"].ToString();
            var searchGenre = Request.Form["searchGenre"].ToString();

            //query.GetRandomText(5);

            SearchType = searchType; //we set property to the value we receive, it will reflect visually on a page
            SelectedGenre = searchGenre;
            SearchQuery = query;

            if (!string.IsNullOrEmpty(searchTypeSelected))
            {
                return;
            }

            //if (searchType == "T")
            //{
            //    Movies = (IEnumerable<Movie>)Program.List.SearchTitle(query);
                //} else if (searchType == "K")
                //{
                //    Movies = Program.List.SearchKeyword(query, Movies); //need to correct?
            //}
            //else if (searchType == "G")
            //{
            //    var genre = (GenreEnum)Enum.Parse(typeof(GenreEnum), searchGenre);
            //    Movies = (IEnumerable<Movie>)Program.List.SearchGenre(genre);
            //}
            //else
            //{
            //    throw new ArgumentException("No such search type", "searchType"); //handle cases when input is incorrect
            //}
        }
    }
}