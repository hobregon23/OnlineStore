using AutoMapper;
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
        IRequestRepository Requests { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<User> _userManager;
        protected readonly IMapper _mapper;
        // add all repositories below
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IFeaturedRepository FeaturedProducts { get; }
        public IUserRepository Users { get; }
        public IAddressRepository Addresses { get; }
        public IAddressProvinceRepository Provinces { get; }
        public IRequestRepository Requests { get; }

        public UnitOfWork(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            Products = new ProductRepository(context, userManager); // define clase que implementa la interfaz
            Categories = new CategoryRepository(context, userManager);
            FeaturedProducts = new FeaturedRepository(context, userManager);
            Users = new UserRepository(context, userManager, mapper);
            Addresses = new AddressRepository(context, userManager);
            Provinces = new AddressProvinceRepository(context, userManager);
            Requests = new RequestRepository(context, userManager);
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
