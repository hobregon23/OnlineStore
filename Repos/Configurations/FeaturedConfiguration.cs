using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class FeaturedConfiguration : IEntityTypeConfiguration<FeaturedProduct>
    {
        public void Configure(EntityTypeBuilder<FeaturedProduct> builder)
        {
            builder.HasData(
                new FeaturedProduct
                {
                    Id = 1,
                    Product_id = 1
                },
                new FeaturedProduct
                {
                    Id = 2,
                    Product_id = 3
                },
                new FeaturedProduct
                {
                    Id = 3,
                    Product_id = 6
                },
                new FeaturedProduct
                {
                    Id = 4,
                    Product_id = 8
                }
            );
        }
    }
}
