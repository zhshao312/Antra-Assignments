using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EFRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Purchase>> GetUserPurchases(int UserId)
        {
            var purchaseMovies = await _dbContext.Purchases.Where(p => p.UserId == UserId).Include(p => p.Movie).ToListAsync();
            return purchaseMovies;
        }


    }
}
