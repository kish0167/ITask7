using ITask7.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Controllers.Utils;

public class SearchController(ApplicationDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Users([FromQuery] string prefix, [FromQuery] int limit = 10)
    {
        if (string.IsNullOrWhiteSpace(prefix) || prefix.Length < 2)
            return BadRequest("Prefix must be at least 2 characters");

        var users = await dbContext.Users
            .Where(u => u.Email != null && u.Email.StartsWith(prefix))
            .OrderBy(u => u.Email)
            .Take(limit)
            .Select(u => new { u.Id, u.Email, u.UserName })
            .ToListAsync();

        return Ok(users);
    }
}