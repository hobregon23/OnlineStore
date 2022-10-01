using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<PaginationResponse<Brand>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<List<Brand>> GetAllNotEmpty();
    }

    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Brand>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Brands.AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper()); ;
            if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Brand>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }

        public async Task<List<Brand>> GetAllNotEmpty()
        {
            return await _context.Brands.Include(x => x.Model_list).Where(x => x.Model_list.Count > 0).ToListAsync();
        }
    }
}
