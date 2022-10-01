using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public class JwtAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorage;

        public JwtAuthService(
            UserManager<User> userManager,
            IConfiguration configuration,
            ApplicationDbContext context,
            ILocalStorageService localStorage)
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
            _localStorage = localStorage;
        }

        public async Task<string> GetUserId()
        {
            var username = await GetUsername();
            if (username == null)
                return "";
            var user = await _context.Users.Where(x => x.UserName.Equals(username)).FirstAsync();
            return user.Id;
        }

        public async Task<int> GetUserProvince()
        {
            var jwtToken = await GetToken();
            if (jwtToken == null)
                return 0;
            var username = await GetUsername();
            if (username == null)
                return 0;
            var user = await _context.Users.Include(x => x.Address).Where(x => x.UserName.Equals(username)).FirstAsync();
            return user.Address.Province_id;
        }

        public async Task<string> GetUserRol()
        {
            var jwtToken = await GetToken();
            if (jwtToken == null)
                return "";
            var rol = jwtToken.Claims.First(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
            return rol;
        }

        public async Task<string> GetUsername()
        {
            var jwtToken = await GetToken();
            if (jwtToken == null)
                return "";
            var username = jwtToken.Claims.First(x => x.Type == "unique_name").Value;
            return username;
        }

        public async Task<JwtSecurityToken> GetToken()
        {
            var token = await _localStorage.GetItemAsStringAsync("TOKENKEY");
            if (string.IsNullOrEmpty(token))
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["jwt:key"]))
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            if (DateTime.UtcNow.CompareTo(Convert.ToDateTime(jwtToken.Claims.First(x => x.Type.Contains("piration")).Value)) > 0)
                return null;
            return jwtToken;
        }

        public async Task<bool> IsAuthorized(List<string> roles)
        {
            try
            {
                var username = await GetUsername();
                if (username == null)
                    return false;

                var user = await _context.Users.Where(x => x.UserName.Equals(username)).FirstAsync();
                foreach (var rol in roles)
                {
                    if (await _userManager.IsInRoleAsync(user, rol))
                        return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
