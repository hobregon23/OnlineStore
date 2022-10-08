using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models
{
    public class User : IdentityUser
    {
        public string CI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }
        public bool IsActive { get; set; }
        public bool Is_deleted { get; set; }

        [ForeignKey("Address_id")]
        public virtual Address Address { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int Address_id { get; set; }
    }
}
