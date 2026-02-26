using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryEditController : Controller
{
    public IActionResult Index(Guid inventoryId)
    {
        // _dbApiService.GetInventory(inventoryId);
        return View(new InventoryViewModel());
    }
}