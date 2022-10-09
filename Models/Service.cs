using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Service : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "{0} es requerida.")]
        [Range(1, 100000, ErrorMessage = "{0} debe ser mayor que 0.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        [DataType(DataType.Currency, ErrorMessage = "Cantidad incorrecta")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        [DataType(DataType.Currency, ErrorMessage = "Cantidad incorrecta")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        [DataType(DataType.Currency, ErrorMessage = "Cantidad incorrecta")]
        public decimal Ingreso { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        [DataType(DataType.Currency, ErrorMessage = "Cantidad incorrecta")]
        public decimal GananciaNeta { get; set; }

        public virtual List<Used_Product> Used_products { get; set; } = new List<Used_Product>();
    }
}
