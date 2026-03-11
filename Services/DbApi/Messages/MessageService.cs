using ITask7.Data;
using ITask7.Models.Chat;
using ITask7.Models.Users;

namespace ITask7.Services.DbApi.Messages;

public class MessageService(ApplicationDbContext dbContext) : IMessageService
{
    public async Task AddAsync(ApplicationUser sender, Guid inventoryId, string text)
    {
        var message = new InventoryMessage(sender, inventoryId, text);
        await dbContext.InventoryMessages.AddAsync(message);
        await dbContext.SaveChangesAsync();
    }
}