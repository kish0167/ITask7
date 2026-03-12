using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryController(IAccessControlService accessControlService) : Controller
{
    protected async Task<bool> AdminAccessCheck()
    {
        return await accessControlService.UserHasAdminAccess(User);
    }
    
    protected async Task<bool> CreatorAccessCheck(Guid inventoryId)
    {
        return await accessControlService.UserHasCreatorAccess(inventoryId, User);
    }
    
    protected async Task<bool> WriterAccessCheck(Guid inventoryId)
    {
        return await accessControlService.UserHasWriteAccess(inventoryId, User);
    }

    protected async Task<bool> ActiveUserCheck()
    {
        return await accessControlService.UserHasAuthorizedAccess(User);
    }
}