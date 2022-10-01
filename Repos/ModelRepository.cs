using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        Task<PaginationResponse<Model>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
    }

    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Model>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Models.Include(x => x.Brand).AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());
            if (search_filter.Model_brand_id > 0)
                queryable = queryable.Where(x => x.Brand_id.Equals(search_filter.Model_brand_id));

            if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Model>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }
    }
}
