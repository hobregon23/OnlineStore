
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Address_Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Shipping_price { get; set; }
        public bool IsActive { get; set; }
        public List<Address_State> States { get; set; } = new List<Address_State>();
    }
}
