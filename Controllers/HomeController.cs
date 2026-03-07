using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ITask7.Models;
using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Controllers;

public class HomeController(DbApiService dbApiService, UserManager<ApplicationUser> userManager) : Controller
{
    public async Task<IActionResult> Index()
    {
        ApplicationUser? user = await userManager.GetUserAsync(User);
        HomePageViewModel? viewModel;
        //if (user == null) return Redirect("Unauthorized/Index");
        if (user == null) viewModel = new HomePageViewModel();
        else viewModel = await dbApiService.GetHomePage(user.Id);
        if (viewModel == null) return BadRequest();
        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}