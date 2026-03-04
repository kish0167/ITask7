using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryEditController(ViewModelsProvider viewModelsProvider, DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid inventoryId)
    {
        InventoryViewModel inventory = await viewModelsProvider.GetInventoryViewModel(inventoryId);
        return View(inventory);
    }

    [HttpPost]
    public async Task<IActionResult> EditProperties(InventoryViewModel model)
    {
        bool success = await dbApiService.EditProperties(model);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteFields([FromBody] List<string> fieldsIds, [FromQuery] Guid contextId)
    {
        bool success = await dbApiService.RemoveFields(fieldsIds, contextId);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteAccesses([FromBody] List<string> userIds, [FromQuery] Guid contextId)
    {
        bool success = await dbApiService.RemoveAccesses(userIds, contextId);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAccess([FromQuery] string username, [FromBody] Guid inventoryId)
    {
        string? success = await dbApiService.AddAccess(username, inventoryId);
        return Ok(success);
    }
}