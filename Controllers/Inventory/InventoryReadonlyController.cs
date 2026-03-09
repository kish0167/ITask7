using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryReadonlyController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid inventoryId)
    {
        InventoryViewModel? inventory = await dbApiService.GetInventoryViewModel(inventoryId);
        if (inventory == null) return BadRequest("Inventory does not exist");
        return View(inventory);
    }
}