using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IUsedProductRepository : IGenericRepository<Used_Product>
    {
        Task<PaginationResponse<Used_Product>> GetPag(Pagination pagination, string campoSorteo, string ordenSorteo);
    }

    public class UsedProductRepository : GenericRepository<Used_Product>, IUsedProductRepository
    {
        public UsedProductRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<PaginationResponse<Used_Product>> GetPag(Pagination pagination, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.UsedProducts.AsQueryable().OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());
            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Used_Product>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }
    }
}
