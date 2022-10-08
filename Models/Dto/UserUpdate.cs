using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class UserUpdate
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string CI { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5)]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
        public Address Address { get; set; } = new Address() { Province = new Address_Province() };
    }
}
