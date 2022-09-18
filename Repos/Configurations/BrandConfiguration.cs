using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Samsung",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Brand
                {
                    Id = 2,
                    Name = "LG",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Brand
                {
                    Id = 3,
                    Name = "Huawei",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Brand
                {
                    Id = 4,
                    Name = "Xiaomi",
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Brand
                {
                    Id = 5,
                    Name = "IPhone",
                    Created_at = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
