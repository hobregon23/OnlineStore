using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<PaginationResponse<Service>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
    }

    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Service>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Services.Include(x => x.Used_products).ThenInclude(x => x.Product).AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper()); ;
            if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Descripcion.Contains(search_filter.Search_text));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Service>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }
    }
}
