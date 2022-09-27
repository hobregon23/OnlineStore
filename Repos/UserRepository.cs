﻿using AutoMapper;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string campoSorteo, string ordenSorteo);
        Task<string> GetUserRol(string id);
        Task<UserDto> GetUserInfo(string username);
        Task<User> GetByIdIncluding(string id);
        Task<bool> AddNormalUser(UserDto model);
        Task<bool> AddAppUser(UserDto model, string rol);
        Task<bool> UpdateUser(UserUpdate model);
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IToastService _toastService;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper, IToastService toastService) : base(context, userManager)
        {
            _mapper = mapper;
            _toastService = toastService;
        }

        public async Task<PaginationResponse<User>> GetPag(Pagination pagination, string name, string campoSorteo, string ordenSorteo)
        {
            var queryable = _context.Users.Include(x => x.Address).ThenInclude(x => x.Province).OrderByDynamic(campoSorteo, ordenSorteo.ToUpper());
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                queryable = queryable.Where(x => x.Name.Contains(name) || x.Email.Contains(name) || x.UserName.Contains(name) || x.LastName.Contains(name));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<User>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity };
        }

        public async Task<string> GetUserRol(string id)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id.Equals(id)).FirstAsync();
                var roleId = (await _context.UserRoles.Where(x => x.UserId.Equals(id)).FirstAsync()).RoleId;
                return (await _context.Roles.Where(x => x.Id.Equals(roleId)).FirstAsync()).Name;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<UserDto> GetUserInfo(string username)
        {
            try
            {
                var user = await _context.Users.Include(x => x.Address).ThenInclude(x => x.Province).Where(x => x.UserName.Equals(username)).FirstAsync();
                if (user == null)
                {
                    return new UserDto();
                }
                return _mapper.Map<UserDto>(user);
            }
            catch
            {
                return new UserDto();
            }
        }

        public async Task<User> GetByIdIncluding(string id)
        {
            try
            {
                var user = await _context.Users.Include(x => x.Address).ThenInclude(x => x.Province).Where(x => x.Id.Equals(id)).FirstAsync();
                if (user == null)
                {
                    return new User();
                }
                return user;
            }
            catch
            {
                return new User();
            }
        }

        public async Task<bool> AddNormalUser(UserDto model)
        {
            var user = _mapper.Map<User>(model);
            user.IsActive = true;
            user.Created_at = DateTime.Now;
            user.Address = new Address() { Province = null, Address_line = model.Address.Address_line, City = model.Address.City, Postal_code = model.Address.Postal_code, State = model.Address.State, Province_id = model.Address.Province_id };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                _toastService.ShowSuccess("Usuario creado exitosamente", "Genial");
                return true;
            }
            else
            {
                _toastService.ShowError("Revise los datos introducidos", "Error");
                return false;
            }
        }

        public async Task<bool> AddAppUser(UserDto model, string rol)
        {
            if (string.IsNullOrEmpty(rol) || string.IsNullOrWhiteSpace(rol))
                return false;
            var user = _mapper.Map<User>(model);
            user.IsActive = true;
            user.Created_at = DateTime.Now;
            user.Address = new Address() { Province = null, Address_line = model.Address.Address_line, City = model.Address.City, Postal_code = model.Address.Postal_code, State = model.Address.State, Province_id = model.Address.Province_id };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, rol);
                _toastService.ShowSuccess("Usuario creado exitosamente", "Genial");
                return true;
            }
            else
            {
                _toastService.ShowError("Revise los datos introducidos", "Error");
                return false;
            }

        }

        public async Task<bool> UpdateUser(UserUpdate model)
        {
            var user = await _context.Users.Where(x => x.UserName.Equals(model.UserName)).FirstAsync();
            if (string.IsNullOrEmpty(model.NewPassword) || string.IsNullOrWhiteSpace(model.NewPassword))
            {
                var resultCheckPass = await _userManager.CheckPasswordAsync(user, model.OldPassword);
                if (!resultCheckPass)
                {
                    return false;
                }
                else
                {
                    user.Updated_at = DateTime.Now;
                    user.Email = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Name = model.Name;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    Update(user);
                    try
                    {
                        await _context.SaveChangesAsync();
                        _toastService.ShowSuccess("Usuario actualizado exitosamente", "Genial");
                    }
                    catch
                    {
                        _context.Entry(user).State = EntityState.Detached;
                        _toastService.ShowError("Recargue la página", "Error");
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                user.Updated_at = DateTime.Now;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                Update(user);
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        _toastService.ShowSuccess("Usuario actualizado exitosamente", "Genial");
                    }
                    catch
                    {
                        _toastService.ShowError("Recargue la página", "Error");
                        return false;
                    }
                    return true;
                }
                else
                {
                    _context.Entry(user).State = EntityState.Detached;
                    return false;
                }
            }
        }
    }
}
