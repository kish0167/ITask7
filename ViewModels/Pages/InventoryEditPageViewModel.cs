using ITask7.ViewModels.Inventories;

namespace ITask7.ViewModels.Pages;

public class InventoryEditPageViewModel
{
    public InventoryViewModel Inventory { get; set; }
    public string TabOpened { get; set; } = "items";
    public bool CreatorAccess { get; set; } = false;
}