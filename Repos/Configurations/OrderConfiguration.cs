using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class OrderConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasData(
                new Request
                {
                    Id = 1,
                    Address_id = 3,
                    Created_at = DateTime.Now,
                    Dealer_id = "fg3434gre-37dd-4e8d-8faf-xcgre34tgdg",
                    Full_name_receptor = "Frank Jose Antonio",
                    IsActive = true,
                    Need_shipping = true,
                    Price = 11000,
                    Shipping_price = 1500,
                    Status = "Tomado",
                    User_id = "b99e4efb-37dd-4e8d-8faf-15s6d51sd1v6"
                },
                new Request
                {
                    Id = 2,
                    Address_id = 3,
                    Created_at = DateTime.Now,
                    Full_name_receptor = "Henry Obregon Mena",
                    IsActive = true,
                    Need_shipping = true,
                    Price = 7000,
                    Shipping_price = 1500,
                    Status = "Pendiente",
                    User_id = "b99e4efb-37dd-4e8d-8faf-15s6d51sd1v6"
                },
                new Request
                {
                    Id = 3,
                    Address_id = 3,
                    Created_at = DateTime.Now,
                    Full_name_receptor = "Eddy Gonzalez",
                    IsActive = true,
                    Need_shipping = false,
                    Price = 1750,
                    Shipping_price = 0,
                    Status = "Pendiente",
                    User_id = "b99e4efb-37dd-4e8d-8faf-15s6d51sd1v6"
                }
            );
        }
    }
}
