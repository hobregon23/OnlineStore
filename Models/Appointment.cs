using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Appointment : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tipo de cita es requerido.")]
        public string Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.AddDays(1);
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Fullname { get; set; }
    }
}
