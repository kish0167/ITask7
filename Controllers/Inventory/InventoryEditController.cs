using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.Fields;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryEditController(DbApiService dbApiService, UserManager<ApplicationUser> userManager, IInventoryService inventoryService, IFieldService fieldService) : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    private readonly IInventoryService _inventoryService = inventoryService;
    private readonly IFieldService _fieldService = fieldService;

    public async Task<IActionResult> Index(Guid inventoryId, string? tabOpened)
    {
        if (!await WriterAccessCheck(inventoryId)) return BadRequest();
        //InventoryViewModel? inventory = await _dbApiService.GetInventoryViewModel(inventoryId);
        InventoryViewModel? inventory = await _inventoryService.GetByIdAsync(inventoryId);
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
        //bool success = await _dbApiService.EditInventoryProperties(model);
        bool success = await _inventoryService.UpdateAsync(model);
        if (!success) return BadRequest("Update failed");
        return Ok(true);
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete([FromQuery] Guid inventoryId)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        bool success = await _dbApiService.DeleteInventory(inventoryId);
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
        //Guid? id = await _dbApiService.EditFieldProperties(field);
        Guid? id = await _fieldService.UpdateAsync(field);
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