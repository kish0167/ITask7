using ITask7.Data;
using ITask7.Services;
using ITask7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Controllers;

public class AdminPanelController(ApplicationDbContext dbContext)
    : Controller
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var userViewModels = await GetViewModelsFromDb();
        return View(userViewModels);
    }
    
    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> BulkDelete([FromBody] List<string> userIds)
    {
        int deleted = await _dbContext.Users
            .Where(u => userIds.Contains(u.Id))
            .ExecuteDeleteAsync();
        return Ok(new { deleted });
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> BulkBlock([FromBody] List<string> userIds)
    {
        string? blockedRoleId = await _dbContext.Roles
            .Where(r => r.Name == UserRoles.Blocked)
            .Select(r => r.Id)
            .FirstOrDefaultAsync();
        
        var newUserRoles = userIds.Select(userId => new IdentityUserRole<string>
        {
            UserId = userId,
            RoleId = blockedRoleId ?? throw new Exception("role id not found")
        });

        await _dbContext.UserRoles.AddRangeAsync(newUserRoles);
        await _dbContext.SaveChangesAsync();

        return Ok(new { blocked = userIds.Count });
    }
    
    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> BulkUnblock([FromBody] List<string> userIds)
    {
        string? blockedRoleId = await _dbContext.Roles
            .Where(r => r.Name == UserRoles.Blocked)
            .Select(r => r.Id)
            .FirstOrDefaultAsync();
        int deletedCount = await _dbContext.UserRoles
            .Where(ur => userIds.Contains(ur.UserId) && ur.RoleId == blockedRoleId)
            .ExecuteDeleteAsync();
        return Ok(new { deletedCount });
    }
    
    private async Task<List<UserViewModel>> GetViewModelsFromDb()
    {
        var userViewModels = await _dbContext.Users
            .GroupJoin(
                _dbContext.UserRoles.Join(_dbContext.Roles, 
                    ur => ur.RoleId, 
                    r => r.Id, 
                    (ur, r) => new { ur.UserId, RoleName = r.Name }),
                u => u.Id,
                ur => ur.UserId,
                (user, userRoles) => new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = userRoles.Select(ur => ur.RoleName).ToList()
                })
            .ToListAsync();
        return userViewModels;
    }
}