using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Address_line { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Postal_code { get; set; }

        [ForeignKey("Province_id")]
        public virtual Address_Province Province { get; set; }
        public int Province_id { get; set; }
    }
}
