using ITask7.Services;
using ITask7.ViewModels;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class MainController(DbApiService dbApiService) : Controller
{
    public async Task<IActionResult> Index()
    {
        MainPageViewModel viewModel = await dbApiService.GetMainPageViewModel();
        return View(viewModel);
    }
}