using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Fields;
using ITask7.Services.DbApi.Inventories;
using ITask7.Services.DbApi.Items;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryEditController(
    IAccessControlService accessControlService,
    IInventoryService inventoryService,
    IFieldService fieldService,
    IAccessControlService accessService,
    IItemService itemService)
    : InventoryController(accessControlService)
{
    private readonly IInventoryService _inventoryService = inventoryService;
    private readonly IFieldService _fieldService = fieldService;
    private readonly IAccessControlService _accessService = accessService;
    private readonly IItemService _itemService = itemService;

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
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete([FromQuery] Guid inventoryId)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        //bool success = await _dbApiService.DeleteInventory(inventoryId);
        bool success = await _inventoryService.DeleteAsync(inventoryId);
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteFields([FromBody] List<Guid> fieldsIds, [FromQuery] Guid contextId)
    {
        if (!await CreatorAccessCheck(contextId)) return BadRequest();
        //bool success = await _dbApiService.RemoveFields(fieldsIds, contextId);
        bool success = await _fieldService.DeleteAsync(fieldsIds, contextId);
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel? field)
    {
        if (field == null) return BadRequest();
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        //Guid? id = await _dbApiService.AddField(field, inventoryId);
        Guid? id = await _fieldService.AddAsync(field, inventoryId);
        if (id == null) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> EditField([FromQuery] Guid inventoryId, [FromBody] FieldDefinitionViewModel? field)
    {
        if (field == null) return BadRequest();
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        //Guid? id = await _dbApiService.EditFieldProperties(field);
        Guid? id = await _fieldService.UpdateAsync(field);
        if (id == null) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteAccesses([FromBody] List<string> userIds, [FromQuery] Guid contextId)
    {
        if (!await CreatorAccessCheck(contextId)) return BadRequest();
        //bool success = await _dbApiService.RemoveAccesses(userIds, contextId);
        bool success = await _accessService.RevokeAccessAsync(userIds, contextId);
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAccess([FromQuery] string username, [FromBody] Guid inventoryId)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        //bool success = await _dbApiService.AddAccess(username, inventoryId);
        bool success = await _accessService.GrantAccessAsync(username, inventoryId);
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteItems([FromBody] List<Guid> itemsIds, [FromQuery] Guid contextId)
    {
        if (!await WriterAccessCheck(contextId)) return BadRequest();
        //bool success = await _dbApiService.RemoveItems(itemsIds, contextId);
        bool success = await _itemService.DeleteAsync(itemsIds, contextId);
        if (!success) return BadRequest("Action failed");
        return Ok();
    }
}