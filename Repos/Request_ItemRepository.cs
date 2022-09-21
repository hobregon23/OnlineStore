using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IRequest_ItemRepository : IGenericRepository<Request_Item>
    {
    }

    public class Request_ItemRepository : GenericRepository<Request_Item>, IRequest_ItemRepository
    {
        public Request_ItemRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

    }
}
