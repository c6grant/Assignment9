using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {

        //Context Variable
        private MovieListContext context { get; set; }

        private readonly ILogger<HomeController> _logger;


        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieListContext con)
        {
            _logger = logger;
            context = con;
        }

        
        //This action returns the base Index
        public IActionResult Index()
        {
            return View();
        }

        //Returns MovieList w/ the full list of movies
        public IActionResult MovieList()
        {
            return View(context.Movies);  
        }

     
        //Action returns Podcasts view
        public IActionResult Podcasts()
        {
            return View();
        }

        //Get method request to pull up MovieInput view
        [HttpGet]
        public IActionResult MovieInput()
        {
            return View();
        }

        //Post Method for the MovieInput page that adds all contents from form to the DB
        [HttpPost]
        public IActionResult MovieInput(MovieItem appResponse)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(appResponse);
                context.SaveChanges();
                return View("Confirmation", appResponse);        
            }
            return View("Confirmation", appResponse);
        }

        //Get Method for EditMovie view
        [HttpGet]
        public IActionResult EditMovie(MovieItem appResponse)
        {
            return View("EditMovie", appResponse);
        }


        //Post Method for EditMovieSubmit that is called when 'Submit' is clicked on the Edit view
        [HttpPost]
        public IActionResult EditMovieSubmit(MovieItem appResponse)
        {
            context.Movies.Update(appResponse);
            context.SaveChanges();
            return View("MovieList", context.Movies);
        }

        //This action is called when 'Delete' is clicked on the MovieList form
        public IActionResult Delete(MovieItem appResponse)
        {
            context.Movies.Remove(appResponse);
            context.SaveChanges();
            return View("MovieList", context.Movies);
        }

        //This action returns the Privacy page view
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
