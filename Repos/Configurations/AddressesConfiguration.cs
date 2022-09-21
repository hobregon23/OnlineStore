using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class AddressesConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address
                {
                    Id = 1,
                    Address_line = "Calle 5 entre 14 y 16",
                    City = "Coliseo",
                    State = "Jovellanos",
                    Province_id = 5,
                    Postal_code = "44320"
                },
                new Address
                {
                    Id = 2,
                    Address_line = "Calle 15 #1505",
                    City = "Cardenas",
                    State = "Cardenas",
                    Province_id = 5,
                    Postal_code = "58975"
                },
                new Address
                {
                    Id = 3,
                    Address_line = "Calle 25 e/15 y 25 #1505",
                    City = "Pueblo Nuevo",
                    State = "Manizales",
                    Province_id = 3,
                    Postal_code = "58975"
                }
            );
        }
    }
}
