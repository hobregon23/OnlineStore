using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IBannerTopService
    {
        Task<string> Add(BannerTop item);
        Task<PaginationResponse<BannerTop>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<BannerTop> GetById(int id);
        Task<List<BannerTop>> GetAll();
        Task<string> Eliminar(int id);
        Task<string> Update(BannerTop item);
    }

    public class BannerTopService : IBannerTopService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public BannerTopService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(BannerTop item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Image_url) || string.IsNullOrWhiteSpace(item.Image_url))
                {
                    item.Image_url = "img/sin_imagen.jpg";
                }
                await _unitOfWork.Top_Banners.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<BannerTop>> GetAll()
        {
            return (await _unitOfWork.Top_Banners.GetAll()).Where(x => x.IsActive).ToList();
        }

        public async Task<PaginationResponse<BannerTop>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Top_Banners.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<BannerTop> GetById(int id)
        {
            return await _unitOfWork.Top_Banners.GetById(id);
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

                _unitOfWork.Top_Banners.Update(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(BannerTop item)
        {
            item.Updated_at = DateTime.Now;
            _unitOfWork.Top_Banners.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
