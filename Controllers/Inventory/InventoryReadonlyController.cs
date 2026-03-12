using ITask7.Services;
using ITask7.Services.DbApi.Inventories;
using ITask7.Services.DbApi.Items;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Inventory;

public class InventoryReadonlyController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;
    public async Task<IActionResult> Index(Guid inventoryId)
    {
        InventoryViewModel? inventory = await _inventoryService.GetByIdAsync(inventoryId);
        if (inventory == null) return BadRequest("Inventory does not exist");
        return View(inventory);
    }
}