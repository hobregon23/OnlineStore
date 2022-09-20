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
    }

    public class AddressProvinceRepository : GenericRepository<Address_Province>, IAddressProvinceRepository
    {
        public AddressProvinceRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<decimal> GetShipPrice(string name)
        {
            var province = await _context.Address_Provinces.FirstOrDefaultAsync(x => x.Name.Equals(name));
            if (province != null)
                return province.Shipping_price;
            return 0;
        }
    }
}
