using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class SearchFilter
    {
        public string Condition { get; set; } = "all";
        public PriceRange Price_range { get; set; } = new PriceRange();
        public string Category { get; set; }
        public string Search_text { get; set; }
    }
}
