using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieRecommender2022.Data;
using MovieRecommender2022.Web.MovieRecFunctions;

namespace MovieRecommender2022.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var movieList = new MovieList();

            while (true)
            {
                var menuSelection = Menu.GetUserMenuSelection();

                switch (menuSelection) //cause our menu is predefined
                {
                    case "A":
                        AddMovieHelper.Start(movieList); //call the method
                        break;
                    case "D":
                        DeleteMovieHelper.Start(movieList);
                        break;
                    case "F":
                        FindRecommendationHelper.Start(movieList);
                        break;
                    case "E":
                        return;
                }
            }


            //movieList.Add(new Movie("Titanic"));
            //movieList.Add(new Movie("Shrek"));
            //movieList.Add(new Movie("Harry Potter 1"));
            //movieList.Add(new Movie("Harry Potter 2"));
            //movieList.Add(new Movie("Harry Potter 3"));
            //movieList.Add(new Movie("Harry Potter 4"));

            //var movies = movieList.Recommend("Titanic");

            //foreach (var item in movies)
            //{
            //    Console.WriteLine(item);
            //}
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}