using Blazored.LocalStorage;
using Blazored.Toast.Services;
using OnlineStore.Models;
using OnlineStore.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public interface IUserService
    {
        Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string campoSorteo, string ordenSorteo);
        Task<string> GetUserRol(string id);
        Task<UserDto> GetUserInfo();
        Task<User> GetById(string id);
        Task<User> GetByIdIncluding(string id);
        Task<bool> AddNormalUser(UserDto model);
        Task<bool> AddAppUser(UserDto model, string rol);
        Task<bool> UpdateUser(UserUpdate model);
        Task<bool> Update(User user);
        Task<bool> Eliminar(string id);
        Task<bool> Activar(string id);
        Task RestorePassword(string email);
    }

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtAuthService _jwtAuthService;
        private readonly IToastService _toastService;

        public UserService(
            JwtAuthService jwtAuthService,
            IUnitOfWork unitOfWork,
            IToastService toastService)
        {
            _jwtAuthService = jwtAuthService;
            _unitOfWork = unitOfWork;
            _toastService = toastService;
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

        public async Task<User> GetByIdIncluding(string id)
        {
            return await _unitOfWork.Users.GetByIdIncluding(id);
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
            if (!await _jwtAuthService.IsAuthorized(new List<string>() { "Admin", "User", "Delivery", "Worker" }))
                return false;
            _unitOfWork.Addresses.Update(model.Address);
            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.Users.UpdateUser(model);
        }

        public async Task<bool> Update(User user)
        {
            if (!await _jwtAuthService.IsAuthorized(new List<string>() { "Admin" }))
                return false;
            var old_user = await _unitOfWork.Users.GetById(user.Id);
            user.UserName = old_user.UserName;
            _unitOfWork.Addresses.Update(user.Address);
            await _unitOfWork.SaveChangesAsync();
            user.Updated_at = DateTime.Now;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();
            _toastService.ShowSuccess("Usuario actualizado exitosamente", "Genial");
            return true;
        }

        public async Task RestorePassword(string email)
        {
            await _unitOfWork.Users.RestorePassword(email);
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
                _toastService.ShowSuccess("Usuario desactivado exitosamente", "Hecho");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Activar(string id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetById(id);
                if (user.UserName.Equals("admin"))
                    return false;
                user.IsActive = true;
                user.Is_deleted = false;
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveChangesAsync();
                _toastService.ShowSuccess("Usuario activado exitosamente", "Hecho");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
