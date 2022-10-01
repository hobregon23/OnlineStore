using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IBrandService
    {
        Task<string> Add(Brand item);
        Task<PaginationResponse<Brand>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Brand> GetById(int id);
        Task<List<Brand>> GetAll();
        Task<List<Brand>> GetAllNotEmpty();

        Task<string> Eliminar(int id);
        Task<string> Update(Brand item);
    }

    public class BrandService : IBrandService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Brand item)
        {
            var bd = (await _unitOfWork.Brands.GetAll()).FirstOrDefault(x => x.Name.ToUpper().Equals(item.Name.ToUpper()));
            if (bd != null)
                return "Ya existe";
            try
            {
                await _unitOfWork.Brands.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Brand>> GetAll()
        {
            return (await _unitOfWork.Brands.GetAll()).ToList();
        }

        public async Task<List<Brand>> GetAllNotEmpty()
        {
            return await _unitOfWork.Brands.GetAllNotEmpty();
        }

        public async Task<PaginationResponse<Brand>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Brands.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Brand> GetById(int id)
        {
            return await _unitOfWork.Brands.GetById(id);
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

                _unitOfWork.Brands.Update(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(Brand item)
        {
            var bd = (await _unitOfWork.Brands.GetAll()).FirstOrDefault(x => x.Name.ToUpper().Equals(item.Name.ToUpper()));
            if (bd != null && bd.Id != item.Id)
                return "Ya existe";
            _unitOfWork.Brands.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
