using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        
    }

    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }


    }
}
