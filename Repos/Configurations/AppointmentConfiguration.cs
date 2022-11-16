using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;
using System;

namespace OnlineStore.Repos
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasData(
                new Appointment
                {
                    Id = 1,
                    Date = DateTime.Now.AddDays(3),
                    Fullname = "Juan Ernesto",
                    Email = "juan@gmail.com",
                    Type = "Defectación"
                },
                new Appointment
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(1),
                    Fullname = "Julio Cesar",
                    Email = "julio@gmail.com",
                    Type = "Reparar entrada de carga"
                },
                new Appointment
                {
                    Id = 3,
                    Date = DateTime.Now.AddDays(4),
                    Fullname = "Pedro Perez",
                    Email = "pedro@gmail.com",
                    Type = "Cambio de partes y piezas"
                },
                new Appointment
                {
                    Id = 4,
                    Date = DateTime.Now,
                    Fullname = "Juan Jesus",
                    Email = "juan08@gmail.com",
                    Type = "Cambio de partes y piezas"
                }
            );
        }
    }
}
