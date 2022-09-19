using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class CartItem
    {
        public int Product_id { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
