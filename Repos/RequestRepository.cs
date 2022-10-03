using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<Request> GetByIdIncluding(int id);
        Task<List<Request>> GetAllIncluding();
        Task<PaginationResponse<Request>> Track(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo, string user_id);
        Task<PaginationResponse<Request>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo, string rol, int prov_id);
    }

    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<Request> GetByIdIncluding(int id)
        {
            return await _context.Requests.Include(x => x.User).Include(x => x.Address).ThenInclude(x => x.Province).Include(x => x.Request_item_list).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<Request>> GetAllIncluding()
        {
            return await _context.Requests.Include(x => x.User).Include(x => x.Address).ThenInclude(x => x.Province).ToListAsync();
        }

        public async Task<PaginationResponse<Request>> Track(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo, string user_id)
        {
            var queryable = _context.Requests.Include(x => x.User).Include(x => x.Address).ThenInclude(x => x.Province).Where(x => x.User_id.Equals(user_id) && x.Is_deleted == false).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

            if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
            {
                queryable = queryable.Where(x => x.Full_name_receptor.Contains(search_filter.Search_text) || x.User.UserName.Contains(search_filter.Search_text) || x.User.Name.Contains(search_filter.Search_text));
            }

            if (search_filter.Order_Status.Equals("Pendiente"))
            {
                queryable = queryable.Where(x => x.Status.Equals("Pendiente"));
            }
            if (search_filter.Order_Status.Equals("Tomado"))
            {
                queryable = queryable.Where(x => x.Status.Equals("Tomado"));
            }
            if (search_filter.Order_Status.Equals("Terminado"))
            {
                queryable = queryable.Where(x => x.Status.Equals("Terminado"));
            }
            if (search_filter.Order_Status.Equals("Cancelado"))
            {
                queryable = queryable.Where(x => x.Status.Equals("Cancelado"));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<Request>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
        }

        public async Task<PaginationResponse<Request>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo, string rol, int prov_id)
        {
            if (rol.Equals("Admin"))
            {
                var queryable = _context.Requests.Include(x => x.User).Include(x => x.Dealer).Include(x => x.Address).ThenInclude(x => x.Province).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

                if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
                {
                    queryable = queryable.Where(x => x.Full_name_receptor.Contains(search_filter.Search_text) || x.User.UserName.Contains(search_filter.Search_text) || x.User.Name.Contains(search_filter.Search_text));
                }

                if (search_filter.Order_Status.Equals("Pendiente"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Pendiente"));
                }
                if (search_filter.Order_Status.Equals("Tomado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Tomado"));
                }
                if (search_filter.Order_Status.Equals("Terminado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Terminado"));
                }
                if (search_filter.Order_Status.Equals("Cancelado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Cancelado"));
                }

                double count = await queryable.CountAsync();
                double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

                return new PaginationResponse<Request>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
            }
            else
            {
                var queryable = _context.Requests.Include(x => x.User).Include(x => x.Dealer).Include(x => x.Address).ThenInclude(x => x.Province).Where(x => x.Need_shipping && x.Address.Province_id.Equals(prov_id) && x.Is_deleted == false).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());

                if (!string.IsNullOrEmpty(search_filter.Search_text) || !string.IsNullOrWhiteSpace(search_filter.Search_text))
                {
                    queryable = queryable.Where(x => x.Full_name_receptor.Contains(search_filter.Search_text) || x.User.UserName.Contains(search_filter.Search_text) || x.User.Name.Contains(search_filter.Search_text));
                }

                if (search_filter.Order_Status.Equals("Pendiente"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Pendiente"));
                }
                if (search_filter.Order_Status.Equals("Tomado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Tomado"));
                }
                if (search_filter.Order_Status.Equals("Terminado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Terminado"));
                }
                if (search_filter.Order_Status.Equals("Cancelado"))
                {
                    queryable = queryable.Where(x => x.Status.Equals("Cancelado"));
                }

                double count = await queryable.CountAsync();
                double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

                return new PaginationResponse<Request>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity, ItemsTotal = queryable.Count() };
            }
        }
    }
}
