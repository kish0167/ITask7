using ITask7.Models.Users;

namespace ITask7.Services.DbApi.Chat;

public interface IChatService
{
    Task ProcessNewMessage(ApplicationUser sender, Guid inventoryId, string text);
}