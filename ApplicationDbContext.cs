﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Repos;
using System.Linq;

namespace OnlineStore
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProvincesConfiguration());
            modelBuilder.ApplyConfiguration(new StatesConfiguration());
            modelBuilder.ApplyConfiguration(new AddressesConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserInRoleConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FeaturedConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new Order_ItemsConfiguration());
            modelBuilder.ApplyConfiguration(new CenterConfiguration());
            modelBuilder.ApplyConfiguration(new BannerTopConfiguration());
            modelBuilder.ApplyConfiguration(new BannerBottomConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Address_Province> Address_Provinces { get; set; }
        public DbSet<Address_State> Address_States { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Payment_Item> Payment_Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Request_Item> Request_Items { get; set; }
        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Used_Product> UsedProducts { get; set; }
        public DbSet<Cierre> Cierres { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<BannerTop> Top_Banners { get; set; }
        public DbSet<BannerBottom> Bottom_Banners { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
