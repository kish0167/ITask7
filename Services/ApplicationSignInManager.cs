using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ITask7.Services;

public class ApplicationSignInManager(
    UserManager<IdentityUser> userManager,
    IHttpContextAccessor contextAccessor,
    IUserClaimsPrincipalFactory<IdentityUser> claimsFactory,
    IOptions<IdentityOptions> optionsAccessor,
    ILogger<SignInManager<IdentityUser>> logger,
    IAuthenticationSchemeProvider schemes,
    IUserConfirmation<IdentityUser> confirmation)
    : SignInManager<IdentityUser>(userManager,
        contextAccessor,
        claimsFactory,
        optionsAccessor,
        logger, schemes,
        confirmation)
{
    public override async Task<bool> CanSignInAsync(IdentityUser user)
    {
        return ! await UserManager.IsInRoleAsync(user, UserRoles.Blocked) && await base.CanSignInAsync(user);
    }

    public override Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
    {
        
        return base.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
    }
}