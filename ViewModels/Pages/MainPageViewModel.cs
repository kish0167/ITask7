using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels.Pages;

public class MainPageViewModel
{
    public readonly int MaxLatestCount = 15;
    public readonly int MaxPopularCount = 5;
    public List<InventoryViewModel> LatestInventories { get; set; } = new();
    public List<InventoryViewModel> PopularInventories { get; set; } = new();
}