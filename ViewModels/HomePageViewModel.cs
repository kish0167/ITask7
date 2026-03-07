using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels;

public class HomePageViewModel
{
    public List<InventoryViewModel> OwnedInventories { get; set; } = new();
    public List<InventoryViewModel> AvailableInventories { get; set; } = new();

    public void AddToAvailableInventories(IEnumerable<InventoryViewModel> viewModels)
    {
        HashSet<Guid> ownedIds = OwnedInventories.Select(i => i.Id).ToHashSet();
        AvailableInventories.AddRange(viewModels.Where(vm => !ownedIds.Contains(vm.Id)));
    }
}