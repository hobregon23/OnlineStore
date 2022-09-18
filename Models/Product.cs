using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Product : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image_url { get; set; }
        public decimal Price { get; set; }
        public decimal Original_price { get; set; }
        public int Qty { get; set; }
        public string Description { get; set; }
        public bool Is_new { get; set; }

        [ForeignKey("Category_id")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Category_id { get; set; }

        [ForeignKey("Model_id")]
        public virtual Model Model { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Model_id { get; set; }
        public string Brand_name { get; set; }
        public string Model_name { get; set; }
        public string Category_name { get; set; }
    }
}
