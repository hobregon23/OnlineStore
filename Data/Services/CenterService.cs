using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface ICenterService
    {
        Task<string> GetActiveCard();
        Task<PaginationResponse<Center>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo);
        Task<Center> GetById(int id);
    }

    public class CenterService : ICenterService
    {
        private readonly JwtAuthService _jwtAuthService;
        private readonly IUnitOfWork _unitOfWork;

        public CenterService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetActiveCard()
        {
            return (await _unitOfWork.Centers.GetById(1)).Tarjeta_Activa;
        }

        public async Task<PaginationResponse<Center>> GetPag(Pagination pagination, SearchFilter search_filter, string campoSorteo, string ordenSorteo)
        {
            return await _unitOfWork.Centers.GetPag(pagination, search_filter, campoSorteo, ordenSorteo);
        }

        public async Task<Center> GetById(int id)
        {
            return await _unitOfWork.Centers.GetById(id);
        }
    }
}
