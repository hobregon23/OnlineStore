using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class Order_ItemsConfiguration : IEntityTypeConfiguration<Request_Item>
    {
        public void Configure(EntityTypeBuilder<Request_Item> builder)
        {
            builder.HasData(
                new Request_Item
                {
                    Id = 1,
                    Created_at = new DateTime(2022, 09, 30),
                    IsActive = true,
                    Product_id = 1,
                    Qty = 2,
                    Request_id = 1,
                    Total_import = 11000
                },
                new Request_Item
                {
                    Id = 2,
                    Created_at = new DateTime(2022, 10, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 1,
                    Request_id = 2,
                    Total_import = 7000
                },
                new Request_Item
                {
                    Id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Product_id = 3,
                    Qty = 1,
                    Request_id = 3,
                    Total_import = 750
                },
                new Request_Item
                {
                    Id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Product_id = 4,
                    Qty = 1,
                    Request_id = 3,
                    Total_import = 1000
                },
                new Request_Item
                {
                    Id = 5,
                    Created_at = new DateTime(2022, 08, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 2,
                    Request_id = 4,
                    Total_import = 14000
                },
                new Request_Item
                {
                    Id = 6,
                    Created_at = new DateTime(2022, 07, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 1,
                    Request_id = 5,
                    Total_import = 7000
                },
                new Request_Item
                {
                    Id = 7,
                    Created_at = new DateTime(2022, 06, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 3,
                    Request_id = 6,
                    Total_import = 21000
                },
                new Request_Item
                {
                    Id = 8,
                    Created_at = new DateTime(2022, 05, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 2,
                    Request_id = 7,
                    Total_import = 14000
                },
                new Request_Item
                {
                    Id = 9,
                    Created_at = new DateTime(2022, 04, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 1,
                    Request_id = 8,
                    Total_import = 7000
                },
                new Request_Item
                {
                    Id = 10,
                    Created_at = new DateTime(2022, 03, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 4,
                    Request_id = 9,
                    Total_import = 28000
                },
                new Request_Item
                {
                    Id = 11,
                    Created_at = new DateTime(2022, 02, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 2,
                    Request_id = 10,
                    Total_import = 14000
                },
                new Request_Item
                {
                    Id = 12,
                    Created_at = new DateTime(2022, 01, 15),
                    IsActive = true,
                    Product_id = 2,
                    Qty = 3,
                    Request_id = 11,
                    Total_import = 21000
                },
                new Request_Item
                {
                    Id = 13,
                    Created_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                    IsActive = true,
                    Product_id = 10,
                    Qty = 1,
                    Request_id = 12,
                    Total_import = 5500
                },
                new Request_Item
                {
                    Id = 14,
                    Created_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                    IsActive = true,
                    Product_id = 6,
                    Qty = 3,
                    Request_id = 13,
                    Total_import = 1200
                }
            );
        }
    }
}
