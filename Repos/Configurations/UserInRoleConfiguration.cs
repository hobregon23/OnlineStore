﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repos
{
    public class UserInRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "77e11a94-548b-4e84-8088-bb9ddd734042",
                    UserId = "a77d4efb-37dd-4e8d-8faf-9f84746fe941"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "55e11a94-548b-4e84-8088-sd5gds4g4dsg",
                    UserId = "b99e4efb-37dd-4e8d-8faf-15s6d51sd1v6"
                }
            );
            
        }
    }
}
