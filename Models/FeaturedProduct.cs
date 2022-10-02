using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class FeaturedProduct
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;

        [ForeignKey("Product_id")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Product_id { get; set; }
    }
}
