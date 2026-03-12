using ITask7.Models.Users;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Chat;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Chat;

public class ChatController(IAccessControlService accessControlService, UserManager<ApplicationUser> userManager, IChatService chatService)
    : InventoryController(accessControlService)
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IChatService _chatService = chatService;

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromQuery] Guid inventoryId, [FromBody] string text)
    {
        if (!await ActiveUserCheck()) return BadRequest();
        ApplicationUser? sender = await _userManager.GetUserAsync(User);
        if (sender == null) return BadRequest();
        await _chatService.ProcessNewMessage(sender, inventoryId, text);
        return Ok();
    }
}