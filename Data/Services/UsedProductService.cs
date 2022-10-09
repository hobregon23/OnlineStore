using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IUsedProductService
    {
        Task<string> Add(Used_Product item);
        Task<PaginationResponse<Used_Product>> GetPag(Pagination pagination, string campoSorteo, string ordenSorteo);
        Task<Used_Product> GetById(int id);
        Task<List<Used_Product>> GetAll();
        Task<string> Eliminar(Used_Product item);
    }

    public class UsedProductService : IUsedProductService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public UsedProductService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Used_Product item)
        {
            try
            {
                await _unitOfWork.UsedProducts.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Used_Product>> GetAll()
        {
            return (await _unitOfWork.UsedProducts.GetAll()).ToList();
        }

        public async Task<PaginationResponse<Used_Product>> GetPag(Pagination pagination, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.UsedProducts.GetPag(pagination, campoSorteo, ordenSorteo);
        }

        public async Task<Used_Product> GetById(int id)
        {
            return await _unitOfWork.UsedProducts.GetById(id);
        }

        public async Task<string> Eliminar(Used_Product item)
        {
            try
            {
                _unitOfWork.UsedProducts.Remove(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }
    }
}
