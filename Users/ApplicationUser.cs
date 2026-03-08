using ITask7.Models.Inventories;
using ITask7.ViewModels;
using ITask7.ViewModels.Pages;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Users;

public class ApplicationUser : IdentityUser
{
    public bool IsAdmin { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public ICollection<Inventory> CreatedInventories { get; set; } = new List<Inventory>();
    public ICollection<InventoryAccess> Accesses { get; set; } = new List<InventoryAccess>();
    public ICollection<Item> CreatedItems { get; set; } = new List<Item>();

    public HomePageViewModel GetHomePage()
    {
        return new HomePageViewModel(this);
    }

    public UserViewModel ToViewModel()
    {
        return new UserViewModel(this);
    }

    public string GetStatusText()
    {
        if (IsBlocked) return "🚫 Blocked";
        if (IsAdmin) return "🛡️ Admin";
        return "✅ Active";
    }

    public void Block()
    {
        IsBlocked = true;
    }

    public void UnBlock()
    {
        IsBlocked = false;
    }

    public void MakeAdmin()
    {
        IsAdmin = true;
    }

    public void DeAdmin()
    {
        IsAdmin = false;
    }
}