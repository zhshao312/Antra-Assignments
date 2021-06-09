using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.MVC.Models;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        
        //constructor injection
        public HomeController(IMovieService movieService)
        {
            //_movieService = new MovieService();

            //_movieService should have an instance of a class that implements IMovieSerive
            _movieService = movieService;
        }
        // localhost/Home/Index
        public async Task<IActionResult> Index()
        {
            //we need to go to database and display top revenue movie
            //thin controllers...

            var movies = await _movieService.GetTopRevenueMovies();
            //
            //send the data to the view so that the view can display the top movies
            //1. passing the data from my controller to my view using strongly typed Models; *****most prefered way
            //2. ViewBag
            //3. ViewData

            //ViewBag.MoviesCount = await movies.CountAsync;
            ViewBag.PageTitle = "Top Revenue Movies";
            ViewData["MyCustomData"] = "Some Information";
            return View(movies);
        }
        // localhost/Home/Privacy
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
