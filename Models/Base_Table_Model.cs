using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Base_Table_Model
    {
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Is_deleted { get; set; } = false;
    }
}
