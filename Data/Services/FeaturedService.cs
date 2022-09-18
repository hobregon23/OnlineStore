using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IFeaturedService
    {
        Task<string> Add(FeaturedProduct item);
        Task<List<FeaturedProduct>> GetAll();
        Task<string> Eliminar(int id);
    }

    public class FeaturedService : IFeaturedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public FeaturedService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(FeaturedProduct item)
        {
            try
            {
                await _unitOfWork.FeaturedProducts.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<FeaturedProduct>> GetAll()
        {
            return (await _unitOfWork.FeaturedProducts.GetIncludingProducts()).Take(8).ToList();
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var item = await _unitOfWork.FeaturedProducts.GetById(id);
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
