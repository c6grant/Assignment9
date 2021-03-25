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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(TempStorage.Inputs.Where(r => r.Title != "Independence Day"));
        }

     
        
        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieInput()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieInput(InputResponse appResponse)
        {

            if (ModelState.IsValid)
            {
                TempStorage.AddInput(appResponse);
                return View("Confirmation", appResponse);
            }
            
            return View("MovieInput", appResponse);
        }

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
