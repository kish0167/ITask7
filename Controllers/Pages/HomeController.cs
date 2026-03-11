using System.Diagnostics;
using ITask7.Models;
using ITask7.Models.Users;
using ITask7.Services;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Pages;

public class HomeController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<IActionResult> Index()
    {
        if (!await ActiveUserCheck()) return Redirect(Url.Action("Index", "Main") ?? "");
        ApplicationUser? user = await _userManager.GetUserAsync(User);
        HomePageViewModel? viewModel;
        if (user == null) return Redirect(Url.Action("Index", "Main") ?? "");
        viewModel = await _dbApiService.GetHomePage(user.Id);
        if (viewModel == null) return BadRequest();
        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}