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
                }
            );
        }
    }
}
