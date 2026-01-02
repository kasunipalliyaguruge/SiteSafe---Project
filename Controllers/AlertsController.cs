using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SiteSafe4.Hubs;

public class AlertsController : Controller
{
    private readonly IHubContext<AlertHub> _hub;

    public AlertsController(IHubContext<AlertHub> hub)
    {
        _hub = hub;
    }

    [HttpGet]
    public async Task<IActionResult> Test()
    {
        await _hub.Clients.All.SendAsync(
            "ReceiveAlert",
            "🚨 Helmet not detected on Site A!"
        );

        return Ok("Alert sent");
    }
}
