using ITask7.Data;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class RoleAssigningUserStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null)
    : UserStore<ApplicationUser, IdentityRole, ApplicationDbContext>(context, describer)
{
    
    public override async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = new CancellationToken())
    {
        //Task<IdentityResult> result = base.CreateAsync(user, cancellationToken);
        IdentityResult result = await base.CreateAsync(user, cancellationToken);
        
        Context.UserRoles.Add(new IdentityUserRole<string>
        {
            UserId = user.Id,
            RoleId = (await Context.Roles.FirstAsync(r => r.Name == UserRoles.Active, cancellationToken)).Id
        });
        
        return result;
    }

    public override Task SetEmailAsync(ApplicationUser user, string? email, CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SetEmailAsync(user, email, cancellationToken);
    }
}