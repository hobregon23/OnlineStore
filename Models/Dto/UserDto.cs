using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class UserDto
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
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Updated_at { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Deleted_at { get; set; }
        public bool IsActive { get; set; }
        public bool Is_deleted { get; set; }
        public Address Address { get; set; } = new Address() { Province = new Address_Province() };
    }
}
