using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Request : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User_id")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string User_id { get; set; }

        [ForeignKey("Dealer_id")]
        public virtual User Dealer { get; set; }

        public string Dealer_id { get; set; }

        [ForeignKey("Address_id")]
        public virtual Address Address { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Address_id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public bool Need_shipping { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Full_name_receptor { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public decimal Shipping_price { get; set; }
        public string Details { get; set; }
        public virtual List<Request_Item> Request_item_list { get; set; } = new List<Request_Item>();

    }
}
