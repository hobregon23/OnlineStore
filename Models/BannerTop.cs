using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class BannerTop : Base_Table_Model
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle_Top { get; set; }
        public string SubTitle_Bottom { get; set; }
        public string Link_Type { get; set; }
        public string Link_Value { get; set; }
        public string Image_url { get; set; }
    }
}
