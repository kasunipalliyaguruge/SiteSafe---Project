using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SiteSafe4.Data;
using SiteSafe4.Hubs;
using SiteSafe4.Models;


namespace SiteSafe4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<AlertHub> _hub;
        public ApiController(ApplicationDbContext db, IHubContext<AlertHub> hub)
        {
            _db = db;
            _hub = hub;
        }

        // Example: POST /api/api/alert
        [HttpPost("alert")]
        public async Task<IActionResult> PostAlert([FromBody] AlertCreateDto dto)
        {
            var alert = new Alert
            {
                Type = dto.Type,
                Description = dto.Description,
                CameraId = dto.CameraId
            };
            _db.Alerts.Add(alert);
            await _db.SaveChangesAsync();

            // notify via SignalR
            await _hub.Clients.All.SendAsync("ReceiveAlert", alert.Type.ToString(), alert.Description);
            return Ok(alert);
        }

        public class AlertCreateDto
        {
            public AlertType Type { get; set; }
            public string? Description { get; set; }
            public int? CameraId { get; set; }
        }
    }
}
