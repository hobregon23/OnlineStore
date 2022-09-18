using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Payment_Item : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Payment_id")]
        public virtual Payment Payment { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Payment_id { get; set; }
    }
}
