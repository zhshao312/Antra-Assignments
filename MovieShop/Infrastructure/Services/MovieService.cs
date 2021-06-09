using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICastRepository _castRepository;


        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository, ICastRepository castRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _castRepository = castRepository;

        }
        public async Task<List<MovieCardResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _movieRepository.GetHighestRevenueMovies();

            var MovieCardList = new List<MovieCardResponseModel>();
            foreach(var movie in movies)
            {
                MovieCardList.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                    Title = movie.Title
                });
            }
            return MovieCardList;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetailsById(int id)
        {
            //var movieGenres = await _genreRepository.GetAllGenres();

            var movies = await _movieRepository.GetById(id);
            //var casts = await _castRepository.GetById(id);
            
            //var movieCasts = new CastResponseModel{
            //    Id = casts.Id,
            //    Name = casts.Name,
            //    Gender = casts.Gender,
            //    TmdbUrl = casts.TmdbUrl,
            //    ProfilePath = casts.ProfilePath
            //};


            var MovieDetails = new MovieDetailsResponseModel {
                Id = movies.Id,
                Title = movies.Title,
                BackdropUrl = movies.BackdropUrl,
                PosterUrl = movies.PosterUrl,
                Tagline = movies.Tagline,
                Overview = movies.Overview,
                ImdbUrl = movies.ImdbUrl,
                TmdbUrl = movies.TmdbUrl,
                ReleaseDate = movies.ReleaseDate,
                RunTime = movies.RunTime,
                Budget = movies.Budget,
                Price = movies.Price,
                Revenue = movies.Revenue,
                Rating = movies.Rating,
                //Casts.Add(movieCasts);

                //Genres = movieGenres
            };


            return MovieDetails;

        }
    }

}
