using ITask7.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ITask7.Services;

public class ApplicationSignInManager(
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor contextAccessor,
    IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
    IOptions<IdentityOptions> optionsAccessor,
    ILogger<SignInManager<ApplicationUser>> logger,
    IAuthenticationSchemeProvider schemes,
    IUserConfirmation<ApplicationUser> confirmation)
    : SignInManager<ApplicationUser>(userManager,
        contextAccessor,
        claimsFactory,
        optionsAccessor,
        logger, schemes,
        confirmation)
{
    public override async Task<bool> CanSignInAsync(ApplicationUser user)
    {
        return ! await UserManager.IsInRoleAsync(user, UserRoles.Blocked) && await base.CanSignInAsync(user);
    }

    public override Task SignInAsync(ApplicationUser user, bool isPersistent, string? authenticationMethod = null)
    {
        
        return base.SignInAsync(user, isPersistent, authenticationMethod);
    }
}