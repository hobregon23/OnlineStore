using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Address_State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Province_id")]
        public virtual Address_Province Province { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Province_id { get; set; }
    }
}
