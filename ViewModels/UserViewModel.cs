using ITask7.Models.Users;
using ITask7.Services;
using Microsoft.AspNetCore.Identity;

namespace ITask7.ViewModels;

public class UserViewModel
{
    public string Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public bool IsAdmin { get; set; }
    public string Status { get; set; }
    public string SalesForceId { get; set; }
    public uint RowVersion { get; set; }
    
    public UserViewModel(ApplicationUser user)
    {
        Id = user.Id;
        Username = user.UserName;
        Email = user.Email;
        IsAdmin = user.IsAdmin;
        Status = user.GetStatusText();
        SalesForceId = user.SalesForceId ?? "-";
        RowVersion = user.RowVersion;
    }
}