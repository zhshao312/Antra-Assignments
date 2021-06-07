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

        //localhost/movies
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        //localhost/movies/id
        [HttpGet]
        public IActionResult Movies(int id)
        {
            return View();
        }
        //localhost/movies/TopRated
        [HttpGet]
        public IActionResult TopRated()
        {
            return View();
        }
        //localhost/movies/TopRevenue
        [HttpGet]
        public IActionResult TopRevenue()
        {
            return View();
        }
        //localhost/movies/genre/genreId
        [HttpGet]
        public IActionResult Genre(int id)
        {
            return View();
        }
        //localhost/movies/id/reviews
        [HttpGet]
        public IActionResult Reviews(int id)
        {
            var movies = _movieService.GetMovieDetailsById(id);
            return View();
        }
    }
}
