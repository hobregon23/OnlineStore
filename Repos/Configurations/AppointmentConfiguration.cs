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
                    Type = "Defectación"
                },
                new Appointment
                {
                    Id = 2,
                    Date = DateTime.Now.AddDays(1),
                    Fullname = "Julio Cesar",
                    Type = "Reparar entrada de carga"
                },
                new Appointment
                {
                    Id = 3,
                    Date = DateTime.Now.AddDays(4),
                    Fullname = "Pedro Perez",
                    Type = "Cambio de partes y piezas"
                },
                new Appointment
                {
                    Id = 4,
                    Date = DateTime.Now,
                    Fullname = "Juan Jesus",
                    Type = "Cambio de partes y piezas"
                }
            );
        }
    }
}
