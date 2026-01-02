using Microsoft.AspNetCore.SignalR;

namespace SiteSafe4.Hubs
{
    public class AlertHub : Hub
    {
        public async Task SendTestAlert(string type, string message)
        {
            await Clients.All.SendAsync("ReceiveAlert", type, message);
        }
    }
}