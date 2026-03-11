using ITask7.Models.Users;
using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryCreateController(DbApiService dbApiService, UserManager<ApplicationUser> userManager)
    : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    [HttpPost]
    public async Task<IActionResult> NewInventory([FromBody] InventoryViewModel? model)
    {
        if (model == null) return BadRequest();
        if (!await ActiveUserCheck()) return BadRequest();
        ApplicationUser? creator = await GetUser();
        if(creator == null) return BadRequest();
        Guid? inventoryId = await _dbApiService.AddNewInventory(model, creator);
        if(inventoryId == null) return BadRequest();
        return Ok(inventoryId);
    }
}