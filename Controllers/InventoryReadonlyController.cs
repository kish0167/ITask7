using ITask7.Services;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryReadonlyController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid inventoryId)
    {
        InventoryViewModel? inventory = await dbApiService.GetInventoryViewModel(inventoryId);
        if (inventory == null) return BadRequest("Inventory does not exist");
        return View(inventory);
    }
}