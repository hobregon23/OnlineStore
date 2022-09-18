using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Repos
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "55e11a94-548b-4e84-8088-sd5gds4g4dsg",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "77e11a94-548b-4e84-8088-bb9ddd734042",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "8871dfhdfh-548b-4e84-8088-df56df51h",
                    Name = "Delivery",
                    NormalizedName = "DELIVERY"
                }
            );
        }
    }
}
