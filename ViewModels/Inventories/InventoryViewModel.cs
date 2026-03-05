using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class InventoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsPublic { get; set; }
    public List<FieldDefinitionViewModel> Fields { get; set; } = new();
    public List<ItemViewModel> Items { get; set; } = new();
    public List<UserViewModel> WriteAccessUsers { get; set; } = new();
    public string? TabOpened { get; set; } = "items";
}