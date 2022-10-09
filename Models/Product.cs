using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Product : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido.")]
        public string Name { get; set; } = string.Empty;

        public string Image_url { get; set; }

        [Required(ErrorMessage = "Precio es requerido.")]
        [Range(1,double.MaxValue, ErrorMessage = "Precio no puede ser 0")]
        public decimal Price { get; set; }

        public decimal Original_price { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Cantidad es requerido.")]
        [Range(1,double.MaxValue, ErrorMessage = "Cantidad no puede ser 0")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Descripión es requerido.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public bool Is_new { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public bool Is_for_sell { get; set; }

        [ForeignKey("Category_id")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Category_id { get; set; }

        [ForeignKey("Model_id")]
        public virtual Model Model { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Model_id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Brand_name { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Model_name { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Category_name { get; set; }
    }
}
