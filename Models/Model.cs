using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Model : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Brand_id")]
        public virtual Brand Brand { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Brand_id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Code_name { get; set; }
    }
}
