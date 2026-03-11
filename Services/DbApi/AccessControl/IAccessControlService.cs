using ITask7.Models.Users;

namespace ITask7.Services.DbApi.AccessControl;

public interface IAccessControlService
{
    Task<bool> GrantAccessAsync(string username, Guid inventoryId);
    Task<bool> RevokeAccessAsync(List<string> userIds, Guid inventoryId);
    Task<bool> CanCreateAsync(Guid inventoryId, ApplicationUser user);
    Task<bool> CanWriteAsync(Guid inventoryId, ApplicationUser user);
}