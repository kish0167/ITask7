using ITask7.RealTimeChat;
using ITask7.Services;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers;

public class ChatController(DbApiService dbApiService, UserManager<ApplicationUser> userManager, ChatService chatService)
    : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ChatService _chatService = chatService;

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromQuery] Guid inventoryId, [FromBody] string text)
    {
        if (!await ActiveUserCheck()) return BadRequest();
        ApplicationUser? sender = await _userManager.GetUserAsync(User);
        if (sender == null) return BadRequest();
        await _dbApiService.AddNewMessage(sender, inventoryId, text);
        await _chatService.BroadcastMessage(sender, inventoryId, text);
        return Ok();
    }
    
    
}