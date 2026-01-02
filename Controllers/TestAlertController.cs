using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Services;

namespace SiteSafe4.Controllers
{
    [ApiController]
    [Route("api/alerts")]
    public class TestAlertController : ControllerBase
    {
        private readonly FcmNotificationService _fcm;

        public TestAlertController(FcmNotificationService fcm)
        {
            _fcm = fcm;
        }

        [HttpPost("test")]
        public async Task<IActionResult> SendTestAlert()
        {
            await _fcm.SendViolationAlertAsync("🔥 Test alert from SiteSafe");
            return Ok("Notification sent");
        }
    }
}
