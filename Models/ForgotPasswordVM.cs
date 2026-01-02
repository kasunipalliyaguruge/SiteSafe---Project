using System.ComponentModel.DataAnnotations;

namespace SiteSafe4.Models
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
    }
}
