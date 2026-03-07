using ITask7.Services;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : Controller
{
    protected async Task<bool> CreatorAccessCheck(Guid inventoryId)
    {
        ApplicationUser? user = await GetUser();
        return user != null && await dbApiService.UserHasCreatorAccess(inventoryId, user);
    }
    
    protected async Task<bool> WriterAccessCheck(Guid inventoryId)
    {
        ApplicationUser? user = await GetUser();
        return user != null && await dbApiService.UserHasWriteAccess(inventoryId, user);
    }

    protected async Task<bool> AuthorizationCheck()
    {
        return await GetUser() != null;
    }

    protected async Task<ApplicationUser?> GetUser()
    {
        return await userManager.GetUserAsync(User);
    }
}