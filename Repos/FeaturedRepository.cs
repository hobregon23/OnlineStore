using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IFeaturedRepository : IGenericRepository<FeaturedProduct>
    {
        Task<List<FeaturedProduct>> GetIncludingProducts();
    }

    public class FeaturedRepository : GenericRepository<FeaturedProduct>, IFeaturedRepository
    {
        public FeaturedRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<List<FeaturedProduct>> GetIncludingProducts()
        {
            return await _context.FeaturedProducts.Include(x => x.Product).ToListAsync();
        }
    }
}
