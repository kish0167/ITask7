using ITask7.RealTimeChat;
using ITask7.Users;
using Microsoft.AspNetCore.SignalR;

namespace ITask7.Services.Chat;

public class ChatService(IHubContext<ChatHub> hubContext)
{
    private readonly IHubContext<ChatHub> _hubContext = hubContext;

    public async Task BroadcastMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        await _hubContext.Clients.Group(inventoryId.ToString())
            .SendAsync("ReceiveMessage", new {
                senderName = sender.UserName,
                text = text,
                sentAt = DateTime.UtcNow
            });
    }
}