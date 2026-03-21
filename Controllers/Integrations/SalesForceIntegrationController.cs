using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Users;
using ITask7.Services.Integrations.SalesForce;
using Microsoft.AspNetCore.Mvc;

namespace ITask7.Controllers.Integrations;

public class SalesForceIntegrationController(IAccessControlService accessControlService, ISalesForceIntegrationService integration, IUserService userService) : InventoryController(accessControlService)
{
    private readonly ISalesForceIntegrationService _integration = integration;
    private readonly IUserService _userService = userService;
    private readonly IAccessControlService _accessControlService = accessControlService;

    [HttpPost]
    public async Task<IActionResult> ConnectToSalesForce([FromBody] AdditionalProfileInfoDto model)
    {
        if (!await _accessControlService.UserCanBeConnectedToSalesForce(User)) return BadRequest();
        string? contactId = await _integration.IntegrateUser(model);
        if (contactId == null) return BadRequest();
        if(!await _userService.SetSalesForceId(model.UserId, contactId)) return BadRequest();
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> DisconnectFromSalesForce([FromQuery] string? userId)
    {
        if (userId == null || !await _userService.RemoveSalesForceId(userId)) return BadRequest();
        return Ok();
    }
}