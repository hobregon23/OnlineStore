using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IModelService
    {
        Task<string> Add(Model item);
        Task<PaginationResponse<Model>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Model> GetById(int id);
        Task<List<Model>> GetAll();
        Task<List<Model>> GetAllByBrand(int id);
        Task<string> Eliminar(int id);
        Task<string> Update(Model item);
    }

    public class ModelService : IModelService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public ModelService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Model item)
        {
            var bd = (await GetAllByBrand(item.Brand_id)).FirstOrDefault(x => x.Name.ToUpper().Equals(item.Name.ToUpper()));
            if (bd != null)
                return "Ya existe";
            try
            {
                await _unitOfWork.Models.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Model>> GetAll()
        {
            return (await _unitOfWork.Models.GetAll()).ToList();
        }

        public async Task<List<Model>> GetAllByBrand(int id)
        {
            return (await _unitOfWork.Models.GetAll()).Where(x => x.Brand_id == id).ToList();
        }

        public async Task<PaginationResponse<Model>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Models.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Model> GetById(int id)
        {
            return await _unitOfWork.Models.GetById(id);
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

                _unitOfWork.Models.Update(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(Model item)
        {
            var bd = (await GetAllByBrand(item.Brand_id)).FirstOrDefault(x => x.Name.ToUpper().Equals(item.Name.ToUpper()));
            if (bd != null && bd.Id != item.Id)
                return "Ya existe";
            _unitOfWork.Models.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
