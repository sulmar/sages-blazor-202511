using Api.BackgroundServices;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        logger.LogInformation("Connected {ConnectionId}", this.Context.ConnectionId);

        return base.OnConnectedAsync();
    }


    public async Task SendDashboardChanged(DashboardItem item)
    {
        if (this.Clients != null)
        {
            await this.Clients.Others.SendAsync("DashboardChanged", item);
        }
    }


    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Disconnected {ConnectionId}", this.Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }
}
