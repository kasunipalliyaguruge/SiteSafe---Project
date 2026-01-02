using System.ComponentModel.DataAnnotations;

namespace SiteSafe4.Models
{
    public class LoginVM
    {
        [Required]
        public string Role { get; set; } = null!;

        [Required]
        public string? Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
