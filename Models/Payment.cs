using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Payment : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public string Serial { get; set; }
        public decimal Import { get; set; }
        public bool Status { get; set; }
        public virtual List<Payment_Item> Payment_item_list { get; set; } = new List<Payment_Item>();
    }
}
