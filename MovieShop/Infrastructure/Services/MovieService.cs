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
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies()
        {
            var movies = await _movieRepository.ListAll();
            var movieModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieModel.Add(new MovieCardResponseModel
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        PosterUrl = movie.PosterUrl,
                        ReleaseDate = (DateTime)movie.ReleaseDate
                    });
            }
            return movieModel;
        }
        public async Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int Id)
        {
            var genre = await _movieRepository.GetById(Id);

            if (genre == null)
            {
                return null;
            }

            var genreMovie = new List<MovieCardResponseModel>();

            foreach (var movieGenre in genre.MovieGenres)
            {
                genreMovie.Add(new MovieCardResponseModel
                {
                    Id = movieGenre.Movie.Id,
                    PosterUrl = movieGenre.Movie.PosterUrl,
                    ReleaseDate = movieGenre.Movie.ReleaseDate.GetValueOrDefault(),
                    Title = movieGenre.Movie.Title
                });
            }

            return genreMovie;
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
