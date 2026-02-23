using ITask7.Services;
using Microsoft.AspNetCore.Identity;

namespace ITask7.ViewModels;

public class UserViewModel
{
    public string Id;
    public string? Email;
    public List<string?> Roles;
    public string Status
    {
        get
        {
            if (Roles.Contains(UserRoles.Blocked))
            {
                return UserRoles.Blocked;
            }

            if(Roles.Contains(UserRoles.Admin))
            {
                return UserRoles.Admin;
            }
            
            return Roles.Contains(UserRoles.Active) ? UserRoles.Active : "no role assigned";
        }
    }
}