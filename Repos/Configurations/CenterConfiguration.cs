using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Models;

namespace OnlineStore.Repos
{
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasData(
                new Center
                {
                    Id = 1,
                    Tarjeta_Activa = "9205 0699 7332 2994",
                    City = "Coliseo",
                    Address = "Calle 5 % 14 y 16",
                    Email = "onlinestore@gmail.com",
                    Horario = "10:00 am a 05:00 pm",
                    PhoneNumber = "+53 53604366",
                    Qr_Code = "/img/tarjetas/qr_cup.jpg"
                }
            );
        }
    }
}
