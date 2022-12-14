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
                    Image_url = "img/products/1.jpg",
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
                    Image_url = "img/products/2.jpg",
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
                    Image_url = "img/products/3.jpg",
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
                    Image_url = "img/products/4.jpg",
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
                    Image_url = "img/products/5.jpg",
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
                    Image_url = "img/products/6.jpg",
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
                    Image_url = "img/products/7.jpg",
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
                    Image_url = "img/products/8.jpg",
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
                    Image_url = "img/products/9.jpg",
                    Description = "Producto nuevo.",
                    Is_new = true,
                    Is_for_sell = false,
                    Qty = 10,
                    Original_price = 5500,
                    Price = 5500,
                    Cost = 1000,
                    Created_at = DateTime.Now.AddDays(1),
                    IsActive = true
                },
                new Product
                {
                    Id = 10,
                    Name = "Pantalla para Huawei P30",
                    Category_id = 1,
                    Model_id = 14,
                    Brand_name = "Huawei",
                    Category_name = "Pantallas",
                    Model_name = "P30",
                    Image_url = "img/products/10.jpg",
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
                    Id = 11,
                    Name = "Cargador para samsung a20",
                    Category_id = 4,
                    Model_id = 2,
                    Brand_name = "Samsung",
                    Category_name = "Cargadores",
                    Model_name = "A20",
                    Image_url = "img/products/11.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 1300,
                    Price = 1000,
                    Cost = 350,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 12,
                    Name = "Tablet A20",
                    Category_id = 6,
                    Model_id = 2,
                    Brand_name = "Samsung",
                    Category_name = "Tabletas",
                    Model_name = "A20",
                    Image_url = "img/products/12.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 15000,
                    Price = 13000,
                    Cost = 9000,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 13,
                    Name = "Auriculares Samsung",
                    Category_id = 7,
                    Model_id = 26,
                    Brand_name = "Samsung",
                    Category_name = "Accesorios",
                    Model_name = "Universal",
                    Image_url = "img/products/13.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 400,
                    Price = 400,
                    Cost = 150,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Product
                {
                    Id = 14,
                    Name = "Auriculares Huawei",
                    Category_id = 7,
                    Model_id = 28,
                    Brand_name = "Huawei",
                    Category_name = "Accesorios",
                    Model_name = "Universal",
                    Image_url = "img/products/14.jpg",
                    Description = "Producto 100% nuevo. Traido desde USA. Original",
                    Is_new = true,
                    Is_for_sell = true,
                    Qty = 10,
                    Original_price = 400,
                    Price = 400,
                    Cost = 150,
                    Created_at = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
