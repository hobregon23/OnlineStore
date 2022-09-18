using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Request : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public string Serial { get; set; }

        [ForeignKey("User_id")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string User_id { get; set; }

        [ForeignKey("Address_id")]
        public virtual Address Address { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Address_id { get; set; }
        public string Status { get; set; }
        public decimal Request_price { get; set; }
        public string Details { get; set; }
        public virtual List<Request_Item> Request_item_list { get; set; } = new List<Request_Item>();

    }
}
