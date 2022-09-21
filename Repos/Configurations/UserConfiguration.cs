using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = "a77d4efb-37dd-4e8d-8faf-9f84746fe941",
                    Created_at = DateTime.Now,
                    Name = "Administrador",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@nauta.cu",
                    NormalizedEmail = "ADMIN@NAUTA.CU",
                    PhoneNumber = "53604366",
                    LastName = "del Sistema",
                    PasswordHash = "AQAAAAEAACcQAAAAEDsAtWGJgjqyvMqMcQVOGaZ0HReabnNrmol+mpQK+2gZJzyVr+s0A7xbT8OIYs9yyw==",
                    IsActive = true,
                    Address_id = 1
                },
                new User
                {
                    Id = "b99e4efb-37dd-4e8d-8faf-15s6d51sd1v6",
                    Created_at = DateTime.Now,
                    Name = "Henry",
                    UserName = "henry23",
                    NormalizedUserName = "HENRY23",
                    Email = "henry23@nauta.cu",
                    NormalizedEmail = "HENRY23@NAUTA.CU",
                    PhoneNumber = "53604366",
                    LastName = "Obregon Mena",
                    PasswordHash = "AQAAAAEAACcQAAAAEDsAtWGJgjqyvMqMcQVOGaZ0HReabnNrmol+mpQK+2gZJzyVr+s0A7xbT8OIYs9yyw==",
                    IsActive = true,
                    Address_id = 3
                }
            );
        }
    }
}
