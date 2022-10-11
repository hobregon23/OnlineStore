using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface ICierreRepository : IGenericRepository<Cierre>
    {
        Task<PaginationResponse<Cierre>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
    }

    public class CierreRepository : GenericRepository<Cierre>, ICierreRepository
    {
        public CierreRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Cierre>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Cierres.AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Cierre>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }
    }
}
