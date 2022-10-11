using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service
                {
                    Id = 1,
                    Cantidad = 1,
                    Costo = 1000,
                    Created_at = DateTime.Now,
                    Descripcion = "Prueba",
                    GananciaNeta = 9000,
                    Ingreso = 10000,
                    Precio = 10000,
                    IsActive = true,
                    Tipo = "Venta"
                },
                new Service
                {
                    Id = 2,
                    Cantidad = 1,
                    Costo = 500,
                    Created_at = DateTime.Now,
                    Descripcion = "Prueba",
                    GananciaNeta = 4500,
                    Ingreso = 5000,
                    Precio = 5000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 3,
                    Cantidad = 1,
                    Costo = 1500,
                    Created_at = DateTime.Now,
                    Descripcion = "Prueba",
                    GananciaNeta = 13500,
                    Ingreso = 15000,
                    Precio = 15000,
                    IsActive = true,
                    Tipo = "Venta"
                }
            );
        }
    }
}
