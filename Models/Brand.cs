using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class Brand : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Name { get; set; }
        public virtual List<Model> Model_list { get; set; } = new List<Model>();
    }
}
