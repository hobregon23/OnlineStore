using Blazored.LocalStorage;
using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IUserService
    {
        public Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string campoSorteo, string ordenSorteo);

        public Task<string> GetUserRol(string id);

        public Task<UserDto> GetUserInfo();

        public Task<User> GetById(string id);

        public Task<bool> AddNormalUser(UserDto model);

        public Task<bool> AddAppUser(UserDto model, string rol);

        public Task<bool> UpdateUser(UserUpdate model);

        public Task<bool> Eliminar(string id);
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public UserService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string campoSorteo, string ordenSorteo)
        {
            if (!await _jwtAuthService.IsAuthorized(new List<string>() { "Admin" }))
                return null;
            return await _unitOfWork.Users.GetPag(pagination, name, campoSorteo, ordenSorteo);
        }

        public async Task<string> GetUserRol(string id)
        {
            return await _unitOfWork.Users.GetUserRol(id);
        }

        public async Task<UserDto> GetUserInfo()
        {
            var username = await _jwtAuthService.GetUsername();
            return await _unitOfWork.Users.GetUserInfo(username);
        }

        public async Task<User> GetById(string id)
        {
            return await _unitOfWork.Users.GetById(id);
        }

        public async Task<bool> AddNormalUser(UserDto model)
        {
            return await _unitOfWork.Users.AddNormalUser(model);
        }

        public async Task<bool> AddAppUser(UserDto model, string rol)
        {
            if (!await _jwtAuthService.IsAuthorized(new List<string>() { "Admin" }))
                return false;
            return await _unitOfWork.Users.AddAppUser(model, rol);
        }

        public async Task<bool> UpdateUser(UserUpdate model)
        {
            if (!await _jwtAuthService.IsAuthorized(new List<string>() { "Admin", "User", "Delivery" }))
                return false;
            _unitOfWork.Addresses.Update(model.Address);
            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.Users.UpdateUser(model);
        }

        public async Task<bool> Eliminar(string id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetById(id);
                if (user.UserName.Equals("admin"))
                    return false;
                user.IsActive = false;
                user.Is_deleted = true;
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
