using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IProductService
    {
        Task<string> Add(Product item);
        Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Product> GetById(int id);
        Task<List<Product>> GetRecents(int qty);
        Task<List<Product>> GetRandom();
        Task<string> Eliminar(int id);
        Task<string> Rebajar(int id, int qty);
    }

    public class ProductService : IProductService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Product item)
        {
            try
            {
                if(string.IsNullOrEmpty(item.Image_url) || string.IsNullOrWhiteSpace(item.Image_url))
                {
                    item.Image_url = "img/sin_imagen.jpg";
                }

                await _unitOfWork.Products.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Products.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetById(id);
        }

        public async Task<List<Product>> GetRecents(int qty)
        {
            return await _unitOfWork.Products.GetRecents(qty);
        }

        public async Task<List<Product>> GetRandom()
        {
            return await _unitOfWork.Products.GetRandom();
        }

        public async Task<string> Rebajar(int id, int qty)
        {
            return await _unitOfWork.Products.Rebajar(id, qty);
        }

        public async Task<string> Eliminar(int id)
        {
            return await _unitOfWork.Products.Eliminar(id);
        }
    }
}
