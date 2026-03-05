using System.Text.Json;
using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryEditController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index(Guid inventoryId, string? tabOpened)
    {
        InventoryViewModel inventory = await dbApiService.GetInventoryViewModel(inventoryId);
        if (tabOpened != null) inventory.TabOpened = tabOpened;
        return View(inventory);
    }

    [HttpPost]
    public async Task<IActionResult> EditProperties(InventoryViewModel model)
    {
        bool success = await dbApiService.EditInventoryProperties(model);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteFields([FromBody] List<Guid> fieldsIds, [FromQuery] Guid contextId)
    {
        bool success = await dbApiService.RemoveFields(fieldsIds, contextId);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel field)
    {
        Guid? id = await dbApiService.AddField(field, inventoryId);
        return Ok(id);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel field)
    {
        Guid? id = await dbApiService.EditFieldProperties(field, inventoryId);
        return Ok(id);
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