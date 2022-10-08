using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Check_Out
    {
        public string Full_name { get; set; }
        public Address Address { get; set; } = new Address() { Province = new Address_Province() };
        public decimal Shipping_price { get; set; }

    }
}
