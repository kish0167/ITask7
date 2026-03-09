using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Item;

public class ItemReadonlyController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid itemId)
    {
        ItemViewModel? item = await dbApiService.GetItemViewModel(itemId);
        if (item == null) return BadRequest("Item does not exist");
        return View(item);
    }
}