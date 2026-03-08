using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class InventoryEditController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;

    public async Task<IActionResult> Index(Guid inventoryId, string? tabOpened)
    {
        if (!await WriterAccessCheck(inventoryId)) return BadRequest();
        InventoryViewModel? inventory = await _dbApiService.GetInventoryViewModel(inventoryId);
        if (inventory == null) return BadRequest("Inventory does not exist");
        inventory.ChatViewModel.CurrentUserName = User.Identity?.Name ?? "noname";
        return View(new InventoryEditPageViewModel()
        {
            Inventory = inventory,
            CreatorAccess = await CreatorAccessCheck(inventoryId),
            TabOpened = tabOpened ?? "items"
        });
    }

    [HttpPost]
    public async Task<IActionResult> EditProperties(InventoryViewModel? model)
    {
        if (model == null) return BadRequest();
        if (!await CreatorAccessCheck(model.Id)) return BadRequest();
        bool success = await _dbApiService.EditInventoryProperties(model);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteFields([FromBody] List<Guid> fieldsIds, [FromQuery] Guid contextId)
    {
        if (!await CreatorAccessCheck(contextId)) return BadRequest();
        bool success = await _dbApiService.RemoveFields(fieldsIds, contextId);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel? field)
    {
        if (field == null) return BadRequest();
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        Guid? id = await _dbApiService.AddField(field, inventoryId);
        return Ok(id);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel? field)
    {
        if (field == null) return BadRequest();
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        Guid? id = await _dbApiService.EditFieldProperties(field, inventoryId);
        return Ok(id);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteAccesses([FromBody] List<string> userIds, [FromQuery] Guid contextId)
    {
        if (!await CreatorAccessCheck(contextId)) return BadRequest();
        bool success = await _dbApiService.RemoveAccesses(userIds, contextId);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAccess([FromQuery] string username, [FromBody] Guid inventoryId)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        bool success = await _dbApiService.AddAccess(username, inventoryId);
        if (!success) return BadRequest();
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteItems([FromBody] List<Guid> itemsIds, [FromQuery] Guid contextId)
    {
        if (!await WriterAccessCheck(contextId)) return BadRequest();
        bool success = await _dbApiService.RemoveItems(itemsIds, contextId);
        return Ok(success);
    }
}