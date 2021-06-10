using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //localhost/Admin/Movie
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieRequestModel CreateMovieRequest)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var createdMovie = await _movieService.CreateMovie(CreateMovieRequest);
            return RedirectToAction("Index");
        }

    }
}
