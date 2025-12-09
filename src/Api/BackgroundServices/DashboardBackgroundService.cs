
using Api.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Api.BackgroundServices;

public class DashboardBackgroundService(ILogger<DashboardBackgroundService> logger, IHubContext<DashboardHub> hub) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {            
            var item = new DashboardItem(Random.Shared.Next(0, 100), Random.Shared.NextDouble() * 100);
            // TODO: wyslic dashboard changed

            // zla praktyka
            // logger.LogInformation($"Send DashboardItem {item.Sessions} {item.Temperature}");

            // dobra praktyka
            logger.LogInformation("Send DashboardItem {Sessions} {Temperature}", item.Sessions, item.Temperature);

            await hub.Clients.All.SendAsync("DashboardChanged", item);

            await Task.Delay(Random.Shared.Next(10, 100));
        }
    }
}


public record DashboardItem(int Sessions, double Temperature);