using ITask7.Users;

namespace ITask7.Services;

public class AccessValidationService(DbApiService dbApiService)
{
    public async Task<bool> UserHasWriteAccess(Guid inventoryId, ApplicationUser user)
    {
        return false;
    }
    
    public async Task<bool> UserHasCreatorAccess(Guid inventoryId, ApplicationUser user)
    {
        return await dbApiService.UserHasCreatorAccess(inventoryId, user);
    }
}