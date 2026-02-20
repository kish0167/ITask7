using ITask7.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class RoleAssigningUserStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null)
    : UserStore<IdentityUser, IdentityRole, ApplicationDbContext>(context, describer)
{
    
    public override async Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken = new CancellationToken())
    {
        Task<IdentityResult> result = base.CreateAsync(user, cancellationToken);
        
        Context.UserRoles.Add(new IdentityUserRole<string>
        {
            UserId = user.Id,
            RoleId = (await Context.Roles.FirstAsync(r => r.Name == UserRoles.Active, cancellationToken)).Id
        });
        
        return await result;
    }

    public override Task SetEmailAsync(IdentityUser user, string? email, CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SetEmailAsync(user, email, cancellationToken);
    }
}