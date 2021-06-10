using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAsyncRepository<Genre> _genreRepository;



        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

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
            var movie = await _movieRepository.GetById(id);


            var MovieDetails = new MovieDetailsResponseModel 
            {
                Id = movie.Id,
                Title = movie.Title,
                BackdropUrl = movie.BackdropUrl,
                PosterUrl = movie.PosterUrl,
                Tagline = movie.Tagline,
                Overview = movie.Overview,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Budget = movie.Budget,
                Price = movie.Price,
                Revenue = movie.Revenue,
                Rating = movie.Rating
            };

            MovieDetails.Genres = new List<GenreResponseModel>();
            MovieDetails.Casts = new List<CastResponseModel>();

            foreach (var cast in movie.MovieCasts) 
            {
                MovieDetails.Casts.Add(new CastResponseModel { Id = cast.CastId, Name = cast.Cast.Name, ProfilePath = cast.Cast.ProfilePath, Character = cast.Character});
            }

            foreach (var genre in movie.MovieGenres)
            {
                MovieDetails.Genres.Add(new GenreResponseModel { Id = genre.Genre.Id, Name = genre.Genre.Name });
            }

            return MovieDetails;

        }

        public async Task<MovieDetailsResponseModel> CreateMovie(CreateMovieRequestModel createMovieRequest)
        {
            //if (_currentUserService.UserId != favoriteRequest.UserId)
            //    throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to purchase");

            // check whether the user is Admin and can create the movie claim

            //var movie = new List<Movie>(createMovieRequest);

            //var createdMovie = await _movieRepository.Add(movie);
            //// var movieGenres = new List<MovieGenre>();
            //foreach (var genre in createMovieRequest.Genres)
            //{
            //    var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
            //    await _genreRepository.Add(movieGenre);
            throw new NotImplementedException();
        }


    
    }

}
