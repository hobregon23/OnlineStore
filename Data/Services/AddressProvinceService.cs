using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IAddressProvinceService
    {
        Task<decimal> GetShipPrice(string name);
        Task<decimal> GetShipPrice(int id);
        Task<List<Address_Province>> GetAll();
        Task<List<Address_Province>> GetAllActive();
        Task<List<Address_State>> GetStatesByProvince(int id);
        Task Update(Address_Province item);
    }

    public class AddressProvinceService : IAddressProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public AddressProvinceService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> GetShipPrice(string name)
        {
            return await _unitOfWork.Provinces.GetShipPrice(name);
        }

        public async Task<decimal> GetShipPrice(int id)
        {
            return await _unitOfWork.Provinces.GetShipPrice(id);
        }

        public async Task<List<Address_Province>> GetAll()
        {
            return await _unitOfWork.Provinces.GetAllIncluding();
        }

        public async Task<List<Address_Province>> GetAllActive()
        {
            return await _unitOfWork.Provinces.GetAllActiveIncluding();
        }

        public async Task Update(Address_Province item)
        {
            _unitOfWork.Provinces.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Address_State>> GetStatesByProvince(int id)
        {
            return await _unitOfWork.Provinces.GetStatesByProvince(id);
        }
    }
}
