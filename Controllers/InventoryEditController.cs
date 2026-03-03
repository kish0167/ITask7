using ITask7.Data;
using ITask7.Services;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Controllers;

public class InventoryEditController(ViewModelsProvider viewModelsProvider, ApplicationDbContext db) : Controller
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
    public IActionResult AddAccess([FromBody] string username)
    {
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> SearchUsers([FromQuery] string prefix, [FromQuery] int limit = 10)
    {
        if (string.IsNullOrWhiteSpace(prefix) || prefix.Length < 2)
            return BadRequest("Prefix must be at least 2 characters");

        var users = await db.Users
            .Where(u => u.Email != null && u.Email.StartsWith(prefix))
            .OrderBy(u => u.Email)
            .Take(limit)
            .Select(u => new { u.Id, u.Email, u.UserName })
            .ToListAsync();

        return Ok(users);
    }

}