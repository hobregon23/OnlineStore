using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Cierre
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime F_inicio { get; set; }
        public DateTime F_fin { get; set; }
        public int Qty_ventas { get; set; }
        public int Qty_reparaciones { get; set; }
        public decimal Costo { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Ganancia { get; set; }

    }
}
