using ITask7.Services;
using ITask7.Users;
using Microsoft.AspNetCore.Identity;

namespace ITask7.ViewModels;

public class UserViewModel
{
    public UserViewModel(ApplicationUser user)
    {
        Id = user.Id;
        Username = user.UserName;
        Email = user.Email;
        Status = user.GetStatusText();
    }

    public string Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string Status { get; set; }
}