using System.ComponentModel.DataAnnotations;

namespace SiteSafe4.Models
{
    public class SupervisorDevice
    {
        public int Id { get; set; }
        public string? FcmToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
