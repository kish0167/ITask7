using ITask7.Data;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class AdminAssigningUserStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null)
    : UserStore<ApplicationUser, IdentityRole, ApplicationDbContext>(context, describer)
{
    
    public override async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = new CancellationToken())
    {
        if (user.Email?.EndsWith("admin") ?? false)
        {
            user.IsAdmin = true; // for showcase only
        }
        IdentityResult result = await base.CreateAsync(user, cancellationToken);
        return result;
    }
}