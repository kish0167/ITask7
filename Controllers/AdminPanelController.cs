using ITask7.Data;
using ITask7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Controllers;

public class AdminPanelController(ApplicationDbContext dbContext)
    : Controller
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<IActionResult> Index()
    {
        var userViewModels = await GetViewModelsFromDb();
        return View(userViewModels);
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