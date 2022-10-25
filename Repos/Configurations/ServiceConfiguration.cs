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
                    Created_at = new DateTime(2022, 09, 30),
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
                    Created_at = new DateTime(2022, 10, 15),
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
                },
                new Service
                {
                    Id = 4,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 08, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 15000,
                    Ingreso = 15000,
                    Precio = 15000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 5,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 07, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 40000,
                    Ingreso = 40000,
                    Precio = 40000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 6,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 06, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 20000,
                    Ingreso = 20000,
                    Precio = 20000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 7,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 05, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 50000,
                    Ingreso = 50000,
                    Precio = 50000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 8,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 04, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 30000,
                    Ingreso = 30000,
                    Precio = 30000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 9,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 03, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 50000,
                    Ingreso = 50000,
                    Precio = 50000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 10,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 02, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 25000,
                    Ingreso = 25000,
                    Precio = 25000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 11,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(2022, 01, 15),
                    Descripcion = "Prueba",
                    GananciaNeta = 48000,
                    Ingreso = 48000,
                    Precio = 48000,
                    IsActive = true,
                    Tipo = "Reparacion"
                },
                new Service
                {
                    Id = 12,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                    Descripcion = "Prueba",
                    GananciaNeta = 7000,
                    Ingreso = 7000,
                    Precio = 7000,
                    IsActive = true,
                    Tipo = "Venta"
                },
                new Service
                {
                    Id = 13,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7),
                    Descripcion = "Prueba",
                    GananciaNeta = 4500,
                    Ingreso = 4500,
                    Precio = 4500,
                    IsActive = true,
                    Tipo = "Venta"
                },
                new Service
                {
                    Id = 14,
                    Cantidad = 1,
                    Costo = 0,
                    Created_at = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14),
                    Descripcion = "Prueba",
                    GananciaNeta = 9000,
                    Ingreso = 9000,
                    Precio = 9000,
                    IsActive = true,
                    Tipo = "Venta"
                }
            );
        }
    }
}
