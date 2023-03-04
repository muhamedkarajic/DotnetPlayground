using Microsoft.AspNetCore.SignalR;

namespace Global;

public class MyHub : Hub
{
    static int TotalUsers = 0;
    public async Task NewWindowLoaded(string payload)
    {
        TotalUsers++;

        await Clients.All.SendAsync("updateTotalViews", TotalUsers);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        TotalUsers--;

        await Clients.All.SendAsync("updateTotalViews", TotalUsers);

        await base.OnDisconnectedAsync(exception);
    }
}
