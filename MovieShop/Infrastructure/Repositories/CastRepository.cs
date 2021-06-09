using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : EFRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetById(int id)
        {
            var cast = await _dbContext.Casts.Where(c => c.Id == id).Include(c => c.MovieCasts)
                                       .ThenInclude(c => c.Movie).FirstOrDefaultAsync();
            return cast;
        }
    }
}
