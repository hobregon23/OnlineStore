using Microsoft.AspNetCore.Identity;
using OnlineStore.Models;
using OnlineStore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        // add all repositories below
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IFeaturedRepository FeaturedProducts { get; }
        IUserRepository Users { get; }
        IAddressRepository Addresses { get; }
        IAddressProvinceRepository Provinces { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<User> _userManager;
        // add all repositories below
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IFeaturedRepository FeaturedProducts { get; }
        public IUserRepository Users { get; }
        public IAddressRepository Addresses { get; }
        public IAddressProvinceRepository Provinces { get; }

        public UnitOfWork(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            Products = new ProductRepository(context, userManager); // define clase que implementa la interfaz
            Categories = new CategoryRepository(context, userManager);
            FeaturedProducts = new FeaturedRepository(context, userManager);
            Users = new UserRepository(context, userManager);
            Addresses = new AddressRepository(context, userManager);
            Provinces = new AddressProvinceRepository(context, userManager);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
