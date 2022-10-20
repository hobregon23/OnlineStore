using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PaginationResponse<Product>> GetPagAdmin(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<List<Product>> GetRecents(int qty);
        Task<List<Product>> GetRandom();
        Task<string> Eliminar(int id);
        Task<string> Rebajar(int id, int qty);
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        //metodos especificos de la clase aqui
        public async Task<List<Product>> GetRecents(int qty)
        {
            return (await _context.Products.Where(x => x.IsActive && x.Is_for_sell).ToListAsync()).OrderByDescending(x => x.Created_at).Take(qty).ToList();
        }

        public async Task<List<Product>> GetRandom()
        {
            var products = await _context.Products.Where(x => x.IsActive && x.Is_for_sell).ToListAsync();
            Random random = new Random();
            var numbers = new int[4] { random.Next(1, products.Count - 1), random.Next(1, products.Count - 1), random.Next(1, products.Count - 1), random.Next(1, products.Count - 1) };
            var respond = new List<Product>();
            foreach (var item in numbers)
            {
                respond.Add(products[item]);
            }
            return respond;
        }

        public async Task<PaginationResponse<Product>> GetPagAdmin(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Products.Include(x => x.Model).ThenInclude(x => x.Brand).Include(x => x.Category).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

            if (!string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text) || x.Category_name.Contains(search_filter.Search_text) || x.Model_name.Contains(search_filter.Search_text) || x.Description.Contains(search_filter.Search_text));
            }
            if (search_filter.Category != null && !search_filter.Category.Equals("all"))
            {
                queryable = queryable.Where(x => x.Category_name.Equals(search_filter.Category));
            }
            if (search_filter.Brand != null && !search_filter.Brand.Equals("all"))
            {
                queryable = queryable.Where(x => x.Brand_name.Equals(search_filter.Brand));
            }

            if (search_filter.Condition.Equals("new"))
            {
                queryable = queryable.Where(x => x.Is_new);
            }
            if (search_filter.Condition.Equals("repaired"))
            {
                queryable = queryable.Where(x => x.Is_new.Equals(false));
            }

            if (search_filter.Price_range.Is_active)
            {
                queryable = queryable.Where(x => x.Price >= search_filter.Price_range.Min && x.Price <= search_filter.Price_range.Max);
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Product>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }

        public async Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Products.Where(x => x.IsActive && x.Is_for_sell).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

            if ((!string.IsNullOrEmpty(search_filter.Category) || !string.IsNullOrWhiteSpace(search_filter.Category)) && (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text)))
            {
                queryable = queryable.Where(x => x.Category_name.Equals(search_filter.Category));
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text) || x.Category_name.Contains(search_filter.Search_text) || x.Model_name.Contains(search_filter.Search_text) || x.Description.Contains(search_filter.Search_text));
            }
            else if (!string.IsNullOrEmpty(search_filter.Category) || !string.IsNullOrWhiteSpace(search_filter.Category))
            {
                queryable = queryable.Where(x => x.Category_name.Equals(search_filter.Category));
            }
            else if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Name.Contains(search_filter.Search_text) || x.Category_name.Contains(search_filter.Search_text) || x.Model_name.Contains(search_filter.Search_text) || x.Description.Contains(search_filter.Search_text));
            }
            if (!string.IsNullOrEmpty(search_filter.Brand) || !string.IsNullOrWhiteSpace(search_filter.Brand))
            {
                queryable = queryable.Where(x => x.Brand_name.Equals(search_filter.Brand));
            }

            if (search_filter.Condition.Equals("new"))
            {
                queryable = queryable.Where(x => x.Is_new);
            }
            if (search_filter.Condition.Equals("repaired"))
            {
                queryable = queryable.Where(x => x.Is_new.Equals(false));
            }

            if (search_filter.Price_range.Is_active)
            {
                queryable = queryable.Where(x => x.Price >= search_filter.Price_range.Min && x.Price <= search_filter.Price_range.Max);
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Product>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }

        public async Task<string> Rebajar(int id, int qty)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                    return "Error, no existe.";
                item.Qty -= qty;
                if (item.Qty < 1)
                    item.IsActive = false;
                Update(item);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                    return "Error, no existe.";
                item.IsActive = false;
                item.Is_deleted = true;
                Update(item);
                await _context.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }
    }
}
