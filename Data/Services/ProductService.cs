using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IProductService
    {
        Task<string> Add(Product item);
        Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<PaginationResponse<Product>> GetPagAdmin(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Product> GetById(int id);
        Task<List<Product>> GetRecents(int qty);
        Task<List<Product>> GetRandom();
        Task<string> Rebajar(int id, int qty);
        Task<string> Update(Product item);
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
                var new_item = new Product()
                {
                    Brand_name = item.Brand_name,
                    Category_id = item.Category_id,
                    Category_name = item.Category_name,
                    Cost = item.Cost,
                    Created_at = DateTime.Now,
                    Description = item.Description,
                    Image_url = item.Image_url,
                    Is_new = item.Is_new,
                    Is_for_sell = item.Is_for_sell,
                    IsActive = true,
                    Model_id = item.Model_id,
                    Model_name = item.Model_name,
                    Name = item.Name,
                    Original_price = item.Price,
                    Price = item.Price,
                    Qty = item.Qty
                };
                if(string.IsNullOrEmpty(new_item.Image_url) || string.IsNullOrWhiteSpace(new_item.Image_url))
                {
                    new_item.Image_url = "img/sin_imagen.jpg";
                }

                await _unitOfWork.Products.Add(new_item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch(Exception e)
            {
                return "Error inesperado. "+e.Message;
            }
        }

        public async Task<PaginationResponse<Product>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Products.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<PaginationResponse<Product>> GetPagAdmin(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Products.GetPagAdmin(pagination, search_filter, campoSorteo, ordenSorteo);
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

        public async Task<string> Update(Product item)
        {
            item.Updated_at = DateTime.Now;
            _unitOfWork.Products.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
