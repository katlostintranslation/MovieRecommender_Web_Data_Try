using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieRecommender2022.Data;
using MovieRecommender2022.Data.Models;

namespace MovieRecommender2022.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieRecommender2022.Data.ApplicationDbContext _context;

        public IndexModel(MovieRecommender2022.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movies != null)
            {
                Movie = await _context.Movies.ToListAsync();
            }
        }
    }
}
