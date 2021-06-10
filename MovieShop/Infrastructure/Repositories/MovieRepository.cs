using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository: EFRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public Task<IEnumerable<Movie>> GetTopRateMovies()
        {
            throw new System.NotImplementedException();
        }

        public override async Task<Movie> GetById(int id)
        {
            //get movie infor from Movie Table
            //get genres by joining moviegenrne, genre
            //rating, avg of movieId Review Table

            var movie = await _dbContext.Movies.Include(m => m.MovieGenres).ThenInclude(m => m.Genre).
                Include(m => m.MovieCasts).ThenInclude(m => m.Cast).
                FirstOrDefaultAsync(m => m.Id == id);

            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty().AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        }
    }
}
