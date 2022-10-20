using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class BannerTopConfiguration : IEntityTypeConfiguration<BannerTop>
    {
        public void Configure(EntityTypeBuilder<BannerTop> builder)
        {
            builder.HasData(
                new BannerTop
                {
                    Id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Title = "Lo mejor <br /> de Huawei",
                    SubTitle_Top = "Encuentra",
                    SubTitle_Bottom = "Todo en un solo lugar",
                    Image_url = "img/hero/banner-1.jpg",
                    Link_Type = "Brand",
                    Link_Value = "Huawei"
                },
                new BannerTop
                {
                    Id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true,
                    Title = "Todo de <br/> Samsung",
                    SubTitle_Top = "Aquí",
                    SubTitle_Bottom = "Siempre pensando en ti",
                    Image_url = "img/hero/banner-2.jpg",
                    Link_Type = "Brand",
                    Link_Value = "Samsung"
                }
            );
        }
    }
}
