using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class PaginationParameters
    {
        public int TotalPageQuantity { get; set; }
        public int QuantityPerPage { get; set; }
        public int CurrentPage { get; set; } = 1;
        public string FieldActualSort { get; set; }
        public string OrderActualSort { get; set; } = "Desc";
        public int itemsTotal { get; set; }
    }
}
