using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryCreateController(IAccessControlService accessControlService, UserManager<ApplicationUser> userManager, IInventoryService inventoryService)
    : InventoryController(accessControlService)
{
    private readonly IInventoryService _inventoryService = inventoryService;
    
    [HttpPost]
    public async Task<IActionResult> NewInventory([FromBody] InventoryViewModel? model)
    {
        if (model == null) return BadRequest();
        if (!await ActiveUserCheck()) return BadRequest();
        ApplicationUser? creator = await userManager.GetUserAsync(User);
        if(creator == null) return BadRequest();
        Guid? inventoryId = await _inventoryService.CreateAsync(model, creator);
        if(inventoryId == null) return BadRequest();
        // return Redirect($"InventoryEdit/Index?inventoryId={inventoryId}"); ???
        return Ok(inventoryId);
    }
}