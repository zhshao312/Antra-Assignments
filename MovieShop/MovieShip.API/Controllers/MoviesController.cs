using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Route("toprevenue")]
        //api/movie/toprevenue
        public async Task<IActionResult> GetHighestGrossingMovie()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No movies found");
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMovie")]
        public async Task<ActionResult> GetMovieByIdAsync(int id)
        {           
            var movie = await _movieService.GetMovieDetailsById(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound("No movie found");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenreId(genreId);
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No movies found");
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("No movies found");
        }


    }
}
