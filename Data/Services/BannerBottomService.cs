using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IBannerBottomService
    {
        Task<string> Add(BannerBottom item);
        Task<PaginationResponse<BannerBottom>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<BannerBottom> GetById(int id);
        Task<List<BannerBottom>> GetAll();
        Task<string> Eliminar(int id);
        Task<string> Update(BannerBottom item);
    }

    public class BannerBottomService : IBannerBottomService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public BannerBottomService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(BannerBottom item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Image_url) || string.IsNullOrWhiteSpace(item.Image_url))
                {
                    item.Image_url = "img/sin_imagen.jpg";
                }
                await _unitOfWork.Bottom_Banners.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<BannerBottom>> GetAll()
        {
            return (await _unitOfWork.Bottom_Banners.GetAll()).Where(x => x.IsActive).ToList();
        }

        public async Task<PaginationResponse<BannerBottom>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Bottom_Banners.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<BannerBottom> GetById(int id)
        {
            return await _unitOfWork.Bottom_Banners.GetById(id);
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

                _unitOfWork.Bottom_Banners.Update(item);
                await _unitOfWork.SaveChangesAsync();
                return "Ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<string> Update(BannerBottom item)
        {
            item.Updated_at = DateTime.Now;
            _unitOfWork.Bottom_Banners.Update(item);
            await _unitOfWork.SaveChangesAsync();
            return "ok";
        }
    }
}
