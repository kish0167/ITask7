using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Item;

public class ItemEditController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<IActionResult> Index(Guid itemId, Guid inventoryId)
    {
        if (!await WriterAccessCheck(inventoryId))
            return BadRequest("You do not have sufficient rights to perform the operation.");
        ItemViewModel? item;
        if (itemId != Guid.Empty) item = await _dbApiService.GetItemViewModel(itemId);
        else item = await _dbApiService.GetEmptyItemViewModel(inventoryId);
        if (item == null) return BadRequest("item does not exist");
        return View(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> SubmitChanges([FromBody] ItemViewModel? model)
    {
        if (model == null) return BadRequest();
        if (!await WriterAccessCheck(model.InventoryId))
            return BadRequest("You do not have sufficient rights to perform the operation.");
        if (!model.CustomId.Validate().IsValid) return BadRequest("Custom id is invalid");
        ApplicationUser? user = await _userManager.GetUserAsync(User);
        if (user == null) return BadRequest();
        Guid? id = await _dbApiService.SaveItem(model, user);
        if (id == null) return BadRequest("Custom id already exists");
        return Ok();
    }
}