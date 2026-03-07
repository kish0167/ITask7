using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels;

public class HomePageViewModel
{
    public List<InventoryViewModel> OwnedInventories { get; set; } = new();
    public List<InventoryViewModel> AvailableInventories { get; set; } = new();

    public void AddToAvailableInventories(IEnumerable<InventoryViewModel> viewModels)
    {
        AvailableInventories.AddRange(viewModels);
    }
}