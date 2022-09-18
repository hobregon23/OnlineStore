using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class PriceRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public bool Is_active { get; set; } = false;
    }
}
