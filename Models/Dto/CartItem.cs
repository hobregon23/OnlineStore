using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class CartItem
    {
        public string Product_name { get; set; }
        public int Product_id { get; set; }
        public string Image_url { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
