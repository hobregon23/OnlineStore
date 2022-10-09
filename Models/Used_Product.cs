using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Used_Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Qty { get; set; }

        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }

        
        public int Product_id { get; set; }

        [ForeignKey("Service_id")]
        public virtual Service Service { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Service_id { get; set; }
    }
}
