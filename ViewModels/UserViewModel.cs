using ITask7.Services;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;

namespace ITask7.ViewModels;

public class UserViewModel
{
    public UserViewModel(ApplicationUser user)
    {

        Id = user.Id;
        Email = user.Email;
        Status = user.GetStatus();
    }

    public string Id { get; set; }
    public string? Email { get; set; }
    public string Status { get; set; }
}