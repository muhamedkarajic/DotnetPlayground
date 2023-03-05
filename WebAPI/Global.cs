using Microsoft.AspNetCore.SignalR;

namespace Global;

public class MyHub : Hub
{
    static Dictionary<string, DateTime> users = new Dictionary<string, DateTime>();

    public async Task ConnectX()
    {
        var connectionId = base.Context.ConnectionId;

        DateTime dateTime = DateTime.Now;
        
        if(users.TryGetValue(connectionId, out DateTime existingDateTime)) {
            dateTime = existingDateTime;
        }
        else
        {
            users.Add(connectionId, dateTime);
        }

        await Clients.All.SendAsync("connectedUsers", users.Count());
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = base.Context.ConnectionId;
        
        users.Remove(connectionId);

        await Clients.All.SendAsync("connectedUsers", users.Count());

        await base.OnDisconnectedAsync(exception);
    }
}
