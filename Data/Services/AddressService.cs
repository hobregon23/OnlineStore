using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IAddressService
    {

    }

    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public AddressService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }


    }
}
