using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Pantallas",
                    Image_url = "img/categories/pantallas.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 2,
                    Name = "Protectores",
                    Image_url = "img/categories/cases.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 3,
                    Name = "Micas",
                    Image_url = "img/categories/micas.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 4,
                    Name = "Cargadores",
                    Image_url = "img/categories/chargers.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 5,
                    Name = "Teléfonos",
                    Image_url = "img/categories/phones.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 6,
                    Name = "Tabletas",
                    Image_url = "img/categories/tablets.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Category
                {
                    Id = 7,
                    Name = "Accesorios",
                    Image_url = "img/categories/accesories.jpg",
                    Created_at = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
