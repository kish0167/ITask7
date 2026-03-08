using Microsoft.AspNetCore.SignalR;

namespace ITask7.RealTimeChat;

public class ChatHub : Hub
{
    public async Task SendMessage(string text)
    {
        string userName = Context.User?.Identity?.Name ?? "noname";
        await Clients.All.SendAsync("ReceiveMessage", userName, text, DateTime.Now);
    }
    
    public async Task Typing()
    {
        string userName = Context.User?.Identity?.Name ?? "noname";
        await Clients.Others.SendAsync("UserTyping", userName);
    }
    
    public async Task JoinInventoryGroup(Guid inventoryId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, inventoryId.ToString());
    }
    
    public override async Task OnConnectedAsync()
    {
        // await Clients.Others.SendAsync("UserJoined", Context.User.Identity.Name);
        await base.OnConnectedAsync();
    }
}