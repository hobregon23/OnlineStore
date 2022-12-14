using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Request_Item : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public decimal Total_import { get; set; }

        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Product_id { get; set; }

        [ForeignKey("Request_id")]
        public virtual Request Request { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Request_id { get; set; }
    }
}
