using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IRequestService
    {
        Task Add(Request item);
        Task<List<Request>> GetAll();
    }

    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public RequestService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Request item)
        {
            await _unitOfWork.Requests.Add(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Request>> GetAll()
        {
            return await _unitOfWork.Requests.GetAllIncludingItems();
        }

    }
}
