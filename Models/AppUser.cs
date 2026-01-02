using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SiteSafe4.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string? UniqueId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Role { get; set; }
    }
}
