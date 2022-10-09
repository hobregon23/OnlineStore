using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pantalla para samsung a10e",
                    Category_id = 1,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Pantallas",
                    Model_name = "A10e",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto reparado.",
                    Is_new = false,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 5500,
                    Price = 5500,
                    Cost = 1000,
                    Created_at = DateTime.Now.AddDays(1),
                    IsActive = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Pantalla para samsung a20",
                    Category_id = 1,
                    Model_id = 2,
                    Brand_name = "Samsung",
                    Category_name = "Pantallas",
                    Model_name = "A20",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 9000,
                    Price = 7000,
                    Cost = 1500,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Protector para samsung a10e",
                    Category_id = 2,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Protectores",
                    Model_name = "A10e",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 7,
                    Original_price = 800,
                    Price = 750,
                    Cost = 300,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Protector para samsung a20",
                    Category_id = 2,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Protectores",
                    Model_name = "A20",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 5,
                    Original_price = 1000,
                    Price = 1000,
                    Cost = 250,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Mica para samsung a20",
                    Category_id = 3,
                    Model_id = 2,
                    Brand_name = "Samsung",
                    Category_name = "Micas",
                    Model_name = "A20",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 5,
                    Original_price = 400,
                    Price = 400,
                    Cost = 150,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 6,
                    Name = "Mica para samsung a10e",
                    Category_id = 3,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Micas",
                    Model_name = "A10e",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 5,
                    Original_price = 500,
                    Price = 400,
                    Cost = 150,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 7,
                    Name = "Telefono a10e nuevo",
                    Category_id = 5,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Teléfonos",
                    Model_name = "A10e",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 5,
                    Original_price = 12000,
                    Price = 12000,
                    Cost = 3000,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 8,
                    Name = "Telefono a20 de uso",
                    Category_id = 5,
                    Model_id = 2,
                    Brand_name = "Samsung",
                    Category_name = "Teléfonos",
                    Model_name = "A20",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto reparado. Como nuevo",
                    Is_new = false,
                    Is_for_sell = true,
                    Qty = 5,
                    Original_price = 14000,
                    Price = 12500,
                    Cost = 3500,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 9,
                    Name = "Pantalla para samsung a10e",
                    Category_id = 1,
                    Model_id = 1,
                    Brand_name = "Samsung",
                    Category_name = "Pantallas",
                    Model_name = "A10e",
                    Image_url = "img/sin_imagen.jpg",
                    Description = "Producto nuevo.",
                    Is_new = false,
                    Is_for_sell = false,
                    Qty = 10,
                    Original_price = 5500,
                    Price = 5500,
                    Cost = 1000,
                    Created_at = DateTime.Now.AddDays(1),
                    IsActive = true
                }
            );
        }
    }
}
