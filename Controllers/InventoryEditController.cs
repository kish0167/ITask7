using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryEditController(ViewModelsProvider viewModelsProvider) : Controller
{
    public async Task<IActionResult> Index(Guid inventoryId)
    {
        InventoryViewModel inventory = await viewModelsProvider.GetInventoryViewModel(inventoryId);
        return View(inventory);
    }

    [HttpPost]
    public IActionResult EditProperties(InventoryViewModel model)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult DeleteAccesses([FromBody] List<string> userIds)
    {
        return Ok();
    }

}