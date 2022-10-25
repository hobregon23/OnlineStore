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
                    GananciaNeta = 5000,
                    Ingreso = 5000,
                    Precio = 5000,
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
                    GananciaNeta = 10000,
                    Ingreso = 10000,
                    Precio = 10000,
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
                    GananciaNeta = 8000,
                    Ingreso = 8000,
                    Precio = 8000,
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
                    GananciaNeta = 5000,
                    Ingreso = 5000,
                    Precio = 5000,
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
                    GananciaNeta = 3000,
                    Ingreso = 3000,
                    Precio = 3000,
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
                    GananciaNeta = 5000,
                    Ingreso = 5000,
                    Precio = 5000,
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
                    GananciaNeta = 7000,
                    Ingreso = 7000,
                    Precio = 7000,
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
                    GananciaNeta = 13000,
                    Ingreso = 13000,
                    Precio = 13000,
                    IsActive = true,
                    Tipo = "Reparacion"
                }
            );
        }
    }
}
