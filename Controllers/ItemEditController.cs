using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class ItemEditController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid itemId, Guid inventoryId)
    {
        ItemViewModel item;
        if (itemId != Guid.Empty) item = await dbApiService.GetItemViewModel(itemId);
        else item = await dbApiService.GetNewItemViewModel(inventoryId);
        return View(item);
    }
    
    [HttpPost]
    public async Task<IActionResult> SubmitChanges(ItemViewModel model)
    {
        Guid? success = await dbApiService.EditItem(model);
        return Ok(success);
    }
}