using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        //Always hve HttpMethod Type Attribute, by default if you dont have anything its HttpGet
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService service)
        {
            _movieService = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View();
        }
    }
}
