using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Users;
using ITask7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Pages;

public class AdminPanelController(IAccessControlService accessControlService, IUserService userService)
    : InventoryController(accessControlService)
{
    private readonly IUserService _userService = userService;
    
    public async Task<IActionResult> Index()
    {
        if (!await AdminAccessCheck()) return Redirect("Home/Index");
        List<UserViewModel> userViewModels = await _userService.GetAllAsync();
        return View(userViewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkDelete([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int deleted = await _userService.Delete(userIds);
        return Ok(deleted);
    }

    [HttpPost]
    public async Task<IActionResult> BulkBlock([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _userService.BlockAsync(userIds);
        return Ok(blocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkUnblock([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int unBlocked = await _userService.UnblockAsync(userIds);
        return Ok(unBlocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkAdmin([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _userService.MakeAdminAsync(userIds);
        return Ok(blocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkDeAdmin([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _userService.RemoveAdminAsync(userIds);
        return Ok(blocked);
    }
}