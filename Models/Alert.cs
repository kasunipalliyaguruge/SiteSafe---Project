namespace SiteSafe4.Models
{
    public class Alert
    {
        public int Id { get; set; }

        // Existing (mapped from AlertType)
        public AlertType Type { get; set; }

        // NEW
        public string Title { get; set; } = string.Empty;

        // Existing renamed logically
        public string? Description { get; set; }   // maps to Message

        public string Severity { get; set; } = "Medium";

        public int? CameraId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // NEW
        public bool IsRead { get; set; } = false;

        // NEW – Identity User Id
        public string? SupervisorId { get; set; }
    }
}
