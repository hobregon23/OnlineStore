using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class BannerBottom : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link_Type { get; set; }
        public string Link_Value { get; set; }
        public string Image_url { get; set; }
    }
}
