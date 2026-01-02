using System;
using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Data;
using SiteSafe4.Models;

namespace SiteSafe4.Controllers
{
    [ApiController]
    [Route("api/fcm")]
    public class FcmController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FcmController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterToken([FromBody] SupervisorDevice device)
        {
            if (!_db.SupervisorDevices.Any(d => d.FcmToken == device.FcmToken))
            {
                _db.SupervisorDevices.Add(device);
                await _db.SaveChangesAsync();
            }

            return Ok(new { message = "FCM token registered" });
        }
    }
}
