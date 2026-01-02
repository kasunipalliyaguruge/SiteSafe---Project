using System.ComponentModel.DataAnnotations;

namespace SiteSafe4.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "ID")]
        public string? UniqueId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
