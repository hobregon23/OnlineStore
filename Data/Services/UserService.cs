using Blazored.LocalStorage;
using OnlineStore.Models;
using OnlineStore.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IUserService
    {
        public Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string token);

        public Task<string> GetUserRol(string userId);

        public Task<UserDto> GetUserInfo();

        public Task<bool> AddNormalUser(UserDto model);

        public Task<bool> AddAppUser(UserDto model, string rol, string token);

        public Task<bool> ActualizarCuenta(string token, UserUpdate userUpdate);

        public Task<bool> Eliminar(string userId);
    }

    public class UserService : IUserService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;

        public UserService(
            ILocalStorageService localStorage,
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork)
        {
            _jwtAuthService = jwtAuthService;
            _localStorage = localStorage;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string token)
        {
            if (!await _jwtAuthService.IsAuthorized(token, new List<string>() { "Admin" }))
                return null;
            return await _unitOfWork.Users.GetPag(pagination, name);
        }

        public async Task<string> GetUserRol(string userId)
        {
            return await _unitOfWork.Users.GetUserRol(userId);
        }

        public async Task<UserDto> GetUserInfo()
        {
            var token = await _localStorage.GetItemAsStringAsync("TOKENKEY");
            var username = _jwtAuthService.GetUsername(token);
            return await _unitOfWork.Users.GetUserInfo(username);
        }

        public async Task<bool> AddNormalUser(UserDto model)
        {
            return await _unitOfWork.Users.AddNormalUser(model);
        }

        public async Task<bool> AddAppUser(UserDto model, string rol, string token)
        {
            if (!await _jwtAuthService.IsAuthorized(token, new List<string>() { "Admin" }))
                return false;
            return await _unitOfWork.Users.AddAppUser(model, rol);
        }

        public async Task<bool> ActualizarCuenta(string token, UserUpdate userUpdate)
        {
            if (!await _jwtAuthService.IsAuthorized(token, new List<string>() { "Admin", "User", "Delivery" }))
                return false;
            return await _unitOfWork.Users.ActualizarCuenta(userUpdate);
        }

        public async Task<bool> Eliminar(string userId)
        {
            try
            {
                var user = await _unitOfWork.Users.GetById(userId);
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
