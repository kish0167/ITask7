using ITask7.Data;
using ITask7.Models.Chat;
using ITask7.Models.Users;
using ITask7.RealTimeChat;
using Microsoft.AspNetCore.SignalR;

namespace ITask7.Services.DbApi.Chat;

public class ChatService(IHubContext<ChatHub> hubContext, ApplicationDbContext dbContext) : IChatService
{
    public async Task ProcessNewMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        await BroadcastMessage(sender, inventoryId, text);
        await SaveMessage(sender, inventoryId, text);
    }
    
    private async Task BroadcastMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        await hubContext.Clients.Group(inventoryId.ToString())
            .SendAsync("ReceiveMessage", new {
                senderName = sender.UserName,
                text = text,
                sentAt = DateTime.UtcNow
            });
    }
    
    private async Task SaveMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        InventoryMessage message = new InventoryMessage(sender, inventoryId, text);
        await dbContext.InventoryMessages.AddAsync(message);
        await dbContext.SaveChangesAsync();
    }
}