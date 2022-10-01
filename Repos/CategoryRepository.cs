using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<PaginationResponse<Category>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Category>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Categories.AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper()); ;
            if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Category>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }
    }
}
