using ITask7.Models.Users;
using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels.Pages;

public class HomePageViewModel
{
    public List<InventoryViewModel> OwnedInventories { get; set; } = new();
    public List<InventoryViewModel> AvailableInventories { get; set; } = new();
    public UserViewModel User { get; set; }
    

    public HomePageViewModel() { }
    
    public HomePageViewModel(ApplicationUser user)
    {
        User = user.ToViewModel();
        OwnedInventories.AddRange(user.CreatedInventories.Select(i => i.ToViewModel()));
        AvailableInventories.AddRange(user.Accesses.Select(a => a.Inventory.ToViewModel()));
    }

    public void AddToAvailableInventories(IEnumerable<InventoryViewModel> viewModels)
    {
        HashSet<Guid> ownedIds = OwnedInventories.Select(i => i.Id).ToHashSet();
        HashSet<Guid> availableIds = AvailableInventories.Select(i => i.Id).ToHashSet();
        AvailableInventories.AddRange(viewModels
            .Where(vm => !ownedIds.Contains(vm.Id) && !availableIds.Contains(vm.Id)));
    }
}