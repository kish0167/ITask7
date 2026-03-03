using System.Runtime.InteropServices.JavaScript;
using ITask7.Data;
using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Controllers;

public class InventoryEditController(ViewModelsProvider viewModelsProvider, DbApiService dbApiService) : Controller
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
    
    [HttpPost]
    public async Task<IActionResult> AddAccess([FromQuery] string username, [FromBody] Guid inventoryId)
    {
        bool success = await dbApiService.AddAccess(username, inventoryId);
        return Ok(success);
    }
}