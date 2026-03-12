using ITask7.Services;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Pages;

public class MainController(IInventoryService inventoryService) : Controller
{
    private readonly IInventoryService _inventoryService = inventoryService;

    public async Task<IActionResult> Index()
    {
        MainPageViewModel viewModel = await _inventoryService.GetMainPageAsync();
        return View(viewModel);
    }
}