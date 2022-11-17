using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;

namespace OnlineStore.Repos
{
    public class ProvincesConfiguration : IEntityTypeConfiguration<Address_Province>
    {
        public void Configure(EntityTypeBuilder<Address_Province> builder)
        {
            builder.HasData(
                new Address_Province
                {
                    Id = 1,
                    Name = "Pinar del Río",
                    Shipping_price = 1500,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 2,
                    Name = "La Habana",
                    Shipping_price = 500,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 3,
                    Name = "Artemisa",
                    Shipping_price = 1000,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 4,
                    Name = "Mayabeque",
                    Shipping_price = 1000,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 5,
                    Name = "Matanzas",
                    Shipping_price = 100,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 6,
                    Name = "Cienfuegos",
                    Shipping_price = 500,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 7,
                    Name = "Villa Clara",
                    Shipping_price = 500,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 8,
                    Name = "Sancti Spíritus",
                    Shipping_price = 1000,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 9,
                    Name = "Ciego de Ávila",
                    Shipping_price = 1500,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 10,
                    Name = "Camaguey",
                    Shipping_price = 2000,
                    IsActive = true
                },
                new Address_Province
                {
                    Id = 11,
                    Name = "Las Tunas",
                    Shipping_price = 2500,
                    IsActive = false
                },
                new Address_Province
                {
                    Id = 12,
                    Name = "Granma",
                    Shipping_price = 3000,
                    IsActive = false
                },
                new Address_Province
                {
                    Id = 13,
                    Name = "Santiago de Cuba",
                    Shipping_price = 3000,
                    IsActive = false
                },
                new Address_Province
                {
                    Id = 14,
                    Name = "Holguín",
                    Shipping_price = 3000,
                    IsActive = false
                },
                new Address_Province
                {
                    Id = 15,
                    Name = "Guantánamo",
                    Shipping_price = 3000,
                    IsActive = false
                }
            );
        }
    }
}
