using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class BannerBottomConfiguration : IEntityTypeConfiguration<BannerBottom>
    {
        public void Configure(EntityTypeBuilder<BannerBottom> builder)
        {
            builder.HasData(
                new BannerBottom
                {
                    Id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Name = "celulares",
                    Image_url = "img/banner/banner-1.jpg",
                    Link_Type = "Category",
                    Link_Value = "Teléfonos"
                },
                new BannerBottom
                {
                    Id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Name = "xiaomi",
                    Image_url = "img/banner/banner-2.jpg",
                    Link_Type = "Brand",
                    Link_Value = "Xiaomi"
                },
                new BannerBottom
                {
                    Id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Name = "huawei",
                    Image_url = "img/banner/banner-3.jpg",
                    Link_Type = "Brand",
                    Link_Value = "Huawei"
                },
                new BannerBottom
                {
                    Id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Name = "celulares",
                    Image_url = "img/banner/banner-4.jpg",
                    Link_Type = "Category",
                    Link_Value = "Teléfonos"
                },
                new BannerBottom
                {
                    Id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Name = "samsung",
                    Image_url = "img/banner/banner-5.jpg",
                    Link_Type = "Brand",
                    Link_Value = "Samsung"
                }
            );
        }
    }
}
