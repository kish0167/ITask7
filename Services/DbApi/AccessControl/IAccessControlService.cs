using System.Security.Claims;
using ITask7.Models.Users;

namespace ITask7.Services.DbApi.AccessControl;

public interface IAccessControlService
{
    Task<bool> GrantAccessAsync(string username, Guid inventoryId);
    Task<bool> RevokeAccessAsync(List<string> userIds, Guid inventoryId);
    Task<bool> UserHasAdminAccess(ClaimsPrincipal claimsPrincipal);
    Task<bool> UserHasCreatorAccess(Guid inventoryId, ClaimsPrincipal claimsPrincipal);
    Task<bool> UserHasWriteAccess(Guid inventoryId, ClaimsPrincipal claimsPrincipal);
    Task<bool> UserHasAuthorizedAccess(ClaimsPrincipal claimsPrincipal);
}