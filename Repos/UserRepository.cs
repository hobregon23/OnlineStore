using AutoMapper;
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
        Task<PaginationResponse<User>> GetPag(Pagination pagination, string name);
        Task<string> GetUserRol(string userId);
        Task<UserDto> GetUserInfo(string username);
        Task<bool> AddNormalUser(UserDto model);
        Task<bool> AddAppUser(UserDto model, string rol);
        Task<bool> ActualizarCuenta(UserUpdate userUpdate);
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper) : base(context, userManager)
        {
            _mapper = mapper;
        }

        public async Task<PaginationResponse<User>> GetPag(Pagination pagination, string name)
        {
            var queryable = _context.Users.Include(x => x.Address).ThenInclude(x => x.Province).AsQueryable();
            if (!string.IsNullOrEmpty(name) || !string.IsNullOrWhiteSpace(name))
            {
                queryable = queryable.Where(x => x.Name.Contains(name) || x.Email.Contains(name) || x.UserName.Contains(name) || x.LastName.Contains(name));
            }

            double count = await queryable.CountAsync();
            double pagesQuantity = Math.Ceiling(count / pagination.QuantityPerPage);

            return new PaginationResponse<User>() { ListaObjetos = await queryable.Paginate(pagination).ToListAsync(), CantPorPag = (int)pagesQuantity };
        }

        public async Task<string> GetUserRol(string userId)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id.Equals(userId)).FirstAsync();
                var roleId = (await _context.UserRoles.Where(x => x.UserId.Equals(userId)).FirstAsync()).RoleId;
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

        public async Task<bool> AddNormalUser(UserDto model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                LastName = model.LastName,
                Created_at = DateTime.Now,
                IsActive = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddAppUser(UserDto model, string rol)
        {
            if (string.IsNullOrEmpty(rol) || string.IsNullOrWhiteSpace(rol))
                return false;

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                LastName = model.LastName,
                Created_at = DateTime.Now,
                IsActive = true
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, rol);
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> ActualizarCuenta(UserUpdate userUpdate)
        {
            var user = await _context.Users.Where(x => x.UserName.Equals(userUpdate.UserName)).FirstAsync();
            if (string.IsNullOrEmpty(userUpdate.NewPassword) || string.IsNullOrWhiteSpace(userUpdate.NewPassword))
            {
                var resultCheckPass = await _userManager.CheckPasswordAsync(user, userUpdate.OldPassword);
                if (!resultCheckPass)
                {
                    return false;
                }
                else
                {
                    user.Email = userUpdate.Email;
                    user.PhoneNumber = userUpdate.PhoneNumber;
                    _context.Entry(user).State = EntityState.Modified;
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        return false;
                    }
                    return true;
                }
            }
            else
            {
                user.Email = userUpdate.Email;
                user.PhoneNumber = userUpdate.PhoneNumber;

                _context.Entry(user).State = EntityState.Modified;

                var result = await _userManager.ChangePasswordAsync(user, userUpdate.OldPassword, userUpdate.NewPassword);
                if (result.Succeeded)
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
