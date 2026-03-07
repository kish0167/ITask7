using ITask7.Models.Inventories;
using ITask7.ViewModels;
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
        HomePageViewModel viewModel = new HomePageViewModel();
        foreach (Inventory inventory in CreatedInventories)
        {
            viewModel.OwnedInventories.Add(inventory.ToViewModel());
        }
        foreach (InventoryAccess access in Accesses)
        {
            viewModel.AvailableInventories.Add(access.Inventory.ToViewModel());
        }

        return viewModel;
    }

    public UserViewModel ToViewModel()
    {
        return new UserViewModel()
        {
            Id = Id,
            Email = Email
        };
    }
}