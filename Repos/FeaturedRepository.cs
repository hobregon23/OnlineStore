using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IFeaturedRepository : IGenericRepository<FeaturedProduct>
    {
        Task<List<FeaturedProduct>> GetIncludingProducts();
        Task<List<FeaturedProduct>> GetIncludingProducts(SearchFilter search_filter, string campoSorteo, string ordenSorteo);
    }

    public class FeaturedRepository : GenericRepository<FeaturedProduct>, IFeaturedRepository
    {
        public FeaturedRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<List<FeaturedProduct>> GetIncludingProducts(SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.FeaturedProducts.Include(x => x.Product).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());
            if (!string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Product.Name.Contains(search_filter.Search_text) || x.Product.Category_name.Contains(search_filter.Search_text) || x.Product.Model_name.Contains(search_filter.Search_text) || x.Product.Description.Contains(search_filter.Search_text));
            }
            if (!search_filter.Category.Equals("all"))
            {
                queryable = queryable.Where(x => x.Product.Category_name.Equals(search_filter.Category));
            }
            if (!search_filter.Brand.Equals("all"))
            {
                queryable = queryable.Where(x => x.Product.Brand_name.Equals(search_filter.Brand));
            }

            if (search_filter.Condition.Equals("new"))
            {
                queryable = queryable.Where(x => x.Product.Is_new);
            }
            if (search_filter.Condition.Equals("repaired"))
            {
                queryable = queryable.Where(x => x.Product.Is_new.Equals(false));
            }
            return await queryable.ToListAsync();
        }

        public async Task<List<FeaturedProduct>> GetIncludingProducts()
        {
            return await _context.FeaturedProducts.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.Product.Model).ThenInclude(x => x.Brand).Where(x => x.Product.Category.IsActive && x.Product.Model.IsActive && x.Product.Model.Brand.IsActive).ToListAsync();
        }
    }
}
