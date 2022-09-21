using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Repos
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<List<Request>> GetAllIncludingItems();
    }

    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }

        public async Task<List<Request>> GetAllIncludingItems()
        {
            var requests = await _context.Requests.ToListAsync();
            var items = await _context.Request_Items.Include(x => x.Product).ToListAsync();
            //foreach (var item in items)
            //{
            //    requests.Find(x => x.Id.Equals(item.Request_id)).Request_item_list.Add(item);
            //}
            foreach (var item in requests)
            {
                var temp = items.FindAll(x => x.Request_id.Equals(item.Id));
                item.Request_item_list = temp;
            }
            return requests;
        }
    }
}
