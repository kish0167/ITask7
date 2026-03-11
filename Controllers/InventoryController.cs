using ITask7.Models.Users;
using ITask7.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : Controller
{
    protected async Task<bool> AdminAccessCheck()
    {
        ApplicationUser? user = await GetUser();
        return user != null && user.IsAdmin && !user.IsBlocked;
    }
    
    protected async Task<bool> CreatorAccessCheck(Guid inventoryId)
    {
        ApplicationUser? user = await GetUser();
        return user != null && await dbApiService.UserHasCreatorAccess(inventoryId, user)  && !user.IsBlocked;
    }
    
    protected async Task<bool> WriterAccessCheck(Guid inventoryId)
    {
        ApplicationUser? user = await GetUser();
        return user != null && await dbApiService.UserHasWriteAccess(inventoryId, user) && !user.IsBlocked;
    }

    protected async Task<bool> ActiveUserCheck()
    {
        ApplicationUser? user = await GetUser();
        return user != null && !user.IsBlocked;
    }

    protected async Task<ApplicationUser?> GetUser()
    {
        return await userManager.GetUserAsync(User);
    }
}