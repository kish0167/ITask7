using ITask7.Services;
using ITask7.Services.DbApi.Items;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Item;

public class ItemReadonlyController(IItemService itemService) : Controller
{
    private readonly IItemService _itemService = itemService;

    public async Task<IActionResult> Index(Guid itemId)
    {
        ItemViewModel? item = await _itemService.GetByIdAsync(itemId);
        if (item == null) return BadRequest("Item does not exist");
        return View(item);
    }
}