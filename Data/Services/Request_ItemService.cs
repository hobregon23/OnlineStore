using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IRequest_ItemService
    {
        Task<string> Add(Request_Item item);
        Task<List<Request_Item>> GetAll();
        Task<string> Eliminar(int id);
    }

    public class Request_ItemService : IRequest_ItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public Request_ItemService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Add(Request_Item item)
        {
            try
            {
                await _unitOfWork.Request_Items.Add(item);
                await _unitOfWork.SaveChangesAsync();
                return "ok";
            }
            catch
            {
                return "Error inesperado.";
            }
        }

        public async Task<List<Request_Item>> GetAll()
        {
            return (await _unitOfWork.Request_Items.GetAll()).ToList();
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
