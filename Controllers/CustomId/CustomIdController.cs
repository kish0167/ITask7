using ITask7.Models.CustomId;
using ITask7.Models.Users;
using ITask7.Services;
using ITask7.ViewModels.CustomId;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.CustomId;

public class CustomIdController(DbApiService dbApiService, UserManager<ApplicationUser> userManager)
    : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    [HttpPost]
    public IActionResult ValidateSchema([FromBody] CustomIdSchema? schema)
    {
        if (schema == null) return BadRequest("schema is null");
        return Ok(schema.Validate());
    }
    
    [HttpPost]
    public async Task<IActionResult> SetSchema([FromQuery] Guid inventoryId, [FromBody] CustomIdSchema? schema)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        if (schema == null) return BadRequest("schema is null");
        if (!schema.Validate().IsValid) BadRequest("Invalid schema");
        bool success = await _dbApiService.SetCustomIdSchema(inventoryId, schema);
        return Ok(success);
    }
    
    [HttpPost]
    public async Task<IActionResult> ValidateId([FromBody] CustomIdModel? customId)
    {
        if (customId == null) return BadRequest("id is null");
        return Ok(customId.Validate());
    }
}