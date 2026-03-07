using ITask7.Models.Inventories;
using ITask7.Users;
using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels;

public class HomePageViewModel
{
    public List<InventoryViewModel> OwnedInventories { get; set; } = new();
    public List<InventoryViewModel> AvailableInventories { get; set; } = new();
    public bool IsAdmin = false;

    public HomePageViewModel() { }
    
    public HomePageViewModel(ApplicationUser user)
    {
        IsAdmin = user.IsAdmin;
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