using ITask7.Models.CustomId;
using ITask7.Services;
using ITask7.Services.CustomId;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.CustomId;

public class CustomIdController(DbApiService dbApiService, UserManager<ApplicationUser> userManager)
    : InventoryController(dbApiService, userManager)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    [HttpPost]
    public async Task<IActionResult> SetSchema([FromQuery] Guid inventoryId, [FromBody] CustomIdSchema? schema)
    {
        if (!await CreatorAccessCheck(inventoryId)) return BadRequest();
        if (schema == null) return BadRequest("schema is null");
        bool success = await _dbApiService.SetCustomIdSchema(inventoryId, schema);
        return Ok(success);
    }
    
    [HttpPost]
    public IActionResult GeneratePreview([FromBody] CustomIdSchema? schema)
    {
        if (schema == null) return Ok("error fetching preview - schema is null");
        SchemaValidationResult preview = schema.Validate();
        return Ok(preview);
    }
    
    [HttpPost]
    public async Task<IActionResult> ValidateId([FromQuery] Guid inventoryId)
    {
        return Ok(true);
    }
}