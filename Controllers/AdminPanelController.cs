using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class AdminPanelController(DbApiService dbApiService, UserManager<ApplicationUser> userManager)
    : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    public async Task<IActionResult> Index()
    {
        if (!await AdminAccessCheck()) return Redirect("Home/Index");
        List<UserViewModel> userViewModels = await _dbApiService.GetAllUsersViewModels();
        return View(userViewModels);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkDelete([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int deleted = await _dbApiService.DeleteUsers(userIds);
        return Ok(deleted);
    }

    [HttpPost]
    public async Task<IActionResult> BulkBlock([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _dbApiService.BlockUsers(userIds);
        return Ok(blocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkUnblock([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _dbApiService.UnBlockUsers(userIds);
        return Ok(blocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkAdmin([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _dbApiService.MakeUsersAdmin(userIds);
        return Ok(blocked);
    }
    
    [HttpPost]
    public async Task<IActionResult> BulkDeAdmin([FromBody] List<string> userIds)
    {
        if (!await AdminAccessCheck()) return BadRequest();
        int blocked = await _dbApiService.DeAdminUseers(userIds);
        return Ok(blocked);
    }
}