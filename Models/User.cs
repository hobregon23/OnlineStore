using Microsoft.AspNetCore.Identity;
using System;

namespace OnlineStore.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }
        public bool IsActive { get; set; }
        public bool Is_deleted { get; set; }
    }
}
