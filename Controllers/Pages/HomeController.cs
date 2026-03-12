using System.Diagnostics;
using ITask7.Models;
using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Pages;

public class HomeController(
    IAccessControlService accessControlService,
    UserManager<ApplicationUser> userManager,
    IInventoryService inventoryService) 
    : InventoryController(accessControlService)
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IInventoryService _inventoryService = inventoryService;

    public async Task<IActionResult> Index()
    {
        if (!await ActiveUserCheck()) return Redirect(Url.Action("Index", "Main") ?? "");
        ApplicationUser? user = await _userManager.GetUserAsync(User);
        if (user == null) return Redirect(Url.Action("Index", "Main") ?? "");
        HomePageViewModel? viewModel = await _inventoryService.GetHomePageAsync(user.Id);
        if (viewModel == null) return BadRequest();
        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}