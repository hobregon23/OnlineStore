using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IAddressProvinceRepository : IGenericRepository<Address_Province>
    {
        Task<decimal> GetShipPrice(string name);
        Task<decimal> GetShipPrice(int id);
        Task<List<Address_Province>> GetAllIncluding();
        Task<List<Address_Province>> GetAllActiveIncluding();
        Task<List<Address_State>> GetStatesByProvince(int id);
    }

    public class AddressProvinceRepository : GenericRepository<Address_Province>, IAddressProvinceRepository
    {
        public AddressProvinceRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<List<Address_State>> GetStatesByProvince(int id)
        {
            return await _context.Address_States.Where(x => x.Province_id.Equals(id)).ToListAsync();
        }

        public async Task<List<Address_Province>> GetAllActiveIncluding()
        {
            return await _context.Address_Provinces.Include(x => x.States).Where(x => x.IsActive).ToListAsync();
        }

        public async Task<List<Address_Province>> GetAllIncluding()
        {
            return await _context.Address_Provinces.Include(x => x.States).ToListAsync();
        }

        public async Task<decimal> GetShipPrice(string name)
        {
            var province = await _context.Address_Provinces.FirstOrDefaultAsync(x => x.Name.Equals(name));
            if (province != null)
                return province.Shipping_price;
            return 0;
        }
        public async Task<decimal> GetShipPrice(int id)
        {
            var province = await _context.Address_Provinces.FindAsync(id);
            if (province != null)
                return province.Shipping_price;
            return 0;
        }
    }
}
