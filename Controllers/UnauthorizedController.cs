using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class UnauthorizedController : Controller
{
    public async Task<IActionResult> Index()
    {
        return Ok();
    }
}