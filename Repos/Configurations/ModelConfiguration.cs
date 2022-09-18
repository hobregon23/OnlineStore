using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
                //                           samsung
                new Model
                {
                    Id = 1,
                    Name = "A10e",
                    Code_name = "a102u",
                    Brand_id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 2,
                    Name = "A20",
                    Code_name = "a205",
                    Brand_id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 3,
                    Name = "S21 5G",
                    Code_name = "G991U",
                    Brand_id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 4,
                    Name = "S22",
                    Code_name = "S901",
                    Brand_id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 5,
                    Name = "J7 Prime",
                    Code_name = "G610F",
                    Brand_id = 1,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                //                           lg
                new Model
                {
                    Id = 6,
                    Name = "Phoenix 2",
                    Code_name = "K371",
                    Brand_id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 7,
                    Name = "K10",
                    Code_name = "K430",
                    Brand_id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 8,
                    Name = "Stylo",
                    Code_name = "H631",
                    Brand_id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 9,
                    Name = "Tribute HD",
                    Code_name = "LS676",
                    Brand_id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 10,
                    Name = "V10",
                    Code_name = "H960",
                    Brand_id = 2,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                //                           huawei
                new Model
                {
                    Id = 11,
                    Name = "Ascend",
                    Code_name = "Y221",
                    Brand_id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 12,
                    Name = "Y360",
                    Code_name = "Y360",
                    Brand_id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 13,
                    Name = "P20",
                    Code_name = "EML-L09",
                    Brand_id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 14,
                    Name = "P30",
                    Code_name = "ELE-L29",
                    Brand_id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 15,
                    Name = "P40 Pro",
                    Code_name = "ELS-N04",
                    Brand_id = 3,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                //                           xiaomi
                new Model
                {
                    Id = 16,
                    Name = "Redmi 8",
                    Code_name = "M1908",
                    Brand_id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 17,
                    Name = "Mi 9",
                    Code_name = "M1909",
                    Brand_id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 18,
                    Name = "Redmi 9A",
                    Code_name = "M2006",
                    Brand_id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 19,
                    Name = "Redmi 9T",
                    Code_name = "M2010",
                    Brand_id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 20,
                    Name = "Mi 9T",
                    Code_name = "M1920",
                    Brand_id = 4,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                //                           iphone
                new Model
                {
                    Id = 21,
                    Name = "12 Pro Max",
                    Code_name = "A2342",
                    Brand_id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 22,
                    Name = "13 Pro",
                    Code_name = "A2639",
                    Brand_id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 23,
                    Name = "6",
                    Code_name = "A1549",
                    Brand_id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 24,
                    Name = "5",
                    Code_name = "A1429",
                    Brand_id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true
                },
                new Model
                {
                    Id = 25,
                    Name = "X",
                    Code_name = "A1901",
                    Brand_id = 5,
                    Created_at = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
