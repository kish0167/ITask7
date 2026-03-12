using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.Items;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Item;

public class ItemEditController(DbApiService dbApiService, UserManager<ApplicationUser> userManager, IItemService itemService) : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IItemService _itemService = itemService;

    public async Task<IActionResult> Index(Guid itemId, Guid inventoryId)
    {
        ItemViewModel? item;
        //if (itemId != Guid.Empty) item = await _dbApiService.GetItemViewModel(itemId);
        //else item = await _dbApiService.GetEmptyItemViewModel(inventoryId);
        if (itemId != Guid.Empty) item = await _itemService.GetByIdAsync(itemId);
        else item = await _itemService.GetEmptyAsync(inventoryId);
        if (item == null) return BadRequest("item does not exist");
        if (!await WriterAccessCheck(item.InventoryId)) return BadRequest();
        return View(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> SubmitChanges([FromBody] ItemViewModel? model)
    {
        if (model == null) return BadRequest();
        if (!await WriterAccessCheck(model.InventoryId)) return BadRequest();
        if (!model.CustomId.Validate().IsValid) return BadRequest("Custom id is invalid");
        ApplicationUser? user = await _userManager.GetUserAsync(User);
        if (user == null) return BadRequest();
        //Guid? id = await _dbApiService.SaveItem(model, user);
        Guid? id = await _itemService.SaveAsync(model, user);
        if (id == null) return BadRequest("Custom id already exists");
        return Ok();
    }
}