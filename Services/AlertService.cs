using Microsoft.AspNetCore.SignalR;
using SiteSafe4.Data;
using SiteSafe4.Hubs;
using SiteSafe4.Models;
using SiteSafe4.Services;

public class AlertService : IAlertService
{
    private readonly ApplicationDbContext _context;
    private readonly IHubContext<AlertHub> _hub;

    public AlertService(ApplicationDbContext context, IHubContext<AlertHub> hub)
    {
        _context = context;
        _hub = hub;
    }

    public async Task CreateAlertAsync(Alert alert)
    {
        _context.Alerts.Add(alert);
        await _context.SaveChangesAsync();

        // Send real-time web alert
        await _hub.Clients.User(alert.SupervisorId!)
            .SendAsync("ReceiveAlert", alert);
    }
}
