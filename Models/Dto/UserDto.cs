using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class UserDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Mínimo 5 caracteres")]
        public string UserName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Debe tener 11 caracteres")]
        public string CI { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número inválido")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password, ErrorMessage = "No coinciden")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Updated_at { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Deleted_at { get; set; }
        public bool IsActive { get; set; }
        public bool Is_deleted { get; set; }
        public Address Address { get; set; } = new Address() { Province = new Address_Province(), State = new Address_State() };
    }
}
