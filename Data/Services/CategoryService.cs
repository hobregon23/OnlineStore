using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface ICategoryService
    {
        Task<string> Add(Category item);
        Task<PaginationResponse<Category>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<string> Eliminar(int id);
        Task Update(Category item);
    }

    public class CategoryService : ICategoryService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Category item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Image_url) || string.IsNullOrWhiteSpace(item.Image_url))
                {
                    item.Image_url = "img/sin_imagen.jpg";
                }

                await _unitOfWork.Categories.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return (await _unitOfWork.Categories.GetAll()).ToList();
        }

        public async Task<PaginationResponse<Category>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Categories.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetById(id);
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

                _unitOfWork.Categories.Update(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task Update(Category item)
        {
            _unitOfWork.Categories.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
