using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Center
    {
        [Key]
        public int Id { get; set; }
        public string Tarjeta_Activa { get; set; }
        public string Qr_Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Horario { get; set; }
    }
}
