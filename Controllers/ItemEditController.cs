using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class ItemEditController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index(Guid itemId, Guid inventoryId)
    {
        ItemViewModel? item;
        if (itemId != Guid.Empty) item = await dbApiService.GetItemViewModel(itemId);
        else item = await dbApiService.GetEmptyItemViewModel(inventoryId);
        if (item == null) return BadRequest();
        return View(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> SubmitChanges([FromBody] ItemViewModel? model)
    {
        if (model == null) return BadRequest();
        ApplicationUser? user = await userManager.GetUserAsync(User);
        if (user == null) return BadRequest();
        Guid? id = await dbApiService.EditItem(model, user);
        if (id == null) return BadRequest();
        return Ok();
    }
}