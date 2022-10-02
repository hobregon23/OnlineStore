using Blazored.Toast.Services;
using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IFeaturedService
    {
        Task Add(FeaturedProduct item);
        Task<List<FeaturedProduct>> GetAll();
        Task<List<FeaturedProduct>> GetAll(SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<string> Eliminar(FeaturedProduct item);
    }

    public class FeaturedService : IFeaturedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;
        private readonly IToastService _toastService;

        public FeaturedService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork,
            IToastService toastService)
        {
            _jwtAuthService = jwtAuthService;
            _toastService = toastService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(FeaturedProduct item)
        {
            try
            {
                var db_list = (await _unitOfWork.FeaturedProducts.GetAll()).ToList();
                var db_item = db_list.FirstOrDefault(x => x.Product_id.Equals(item.Product_id));
                if (db_item != null)
                {
                    _toastService.ShowError("Ya es un producto destacado", "Error");
                    return;
                }
                await _unitOfWork.FeaturedProducts.Add(item);
                await _unitOfWork.SaveChangesAsync();
                _toastService.ShowSuccess("Marcado como destacado", "Genial");
                return;
            }
            catch
            {
                return;
            }
        }

        public async Task<List<FeaturedProduct>> GetAll()
        {
            return await _unitOfWork.FeaturedProducts.GetIncludingProducts();
        }

        public async Task<List<FeaturedProduct>> GetAll(SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.FeaturedProducts.GetIncludingProducts(search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<string> Eliminar(FeaturedProduct item)
        {
            try
            {
                if (item == null)
                    return "Error, no existe.";

                _unitOfWork.FeaturedProducts.Remove(item);
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
