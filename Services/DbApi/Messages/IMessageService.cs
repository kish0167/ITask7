using ITask7.Models.Users;

namespace ITask7.Services.DbApi.Messages;

public interface IMessageService
{
    Task AddAsync(ApplicationUser sender, Guid inventoryId, string text);
}