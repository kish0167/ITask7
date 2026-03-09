using Humanizer;
using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.ViewModels.CustomId;

namespace ITask7.ViewModels.Inventories;

public class ItemViewModel
{
    public Guid Id { get; set; }
    public CustomIdViewModel CustomId { get; set; }
    public string CustomIdString => CustomId.ToString();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? CreatedByUserName { get; set; }
    public Dictionary<Guid , FieldValueViewModel> Fields { get; set; } = new();
    public List<FieldDefinitionViewModel> FieldDefinitions { get; set; } = new();
    public Guid InventoryId { get; set; }
    public string CreatedAtString => CreatedAt.Humanize();

    public ItemViewModel(){}
    
    public ItemViewModel(Inventory inventory)
    {
        Id = Guid.Empty;
        InventoryId = inventory.Id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        CreatedByUserName = "none";
        CustomId = new CustomIdViewModel(inventory);
        PopulateFields(inventory);
    }

    public ItemViewModel(Item item)
    {
        Id = item.Id;
        CustomId = new CustomIdViewModel(item.CustomId, item.Inventory);
        CreatedByUserName = item.Creator?.UserName ?? "creator not found";
        CreatedAt = item.CreatedAt;
        UpdatedAt = item.UpdatedAt;
        InventoryId = item.InventoryId;
        foreach (InventoryField field in item.Inventory.Fields)
        {
            ItemFieldValue value = item.TryGetValue(field.Id) ?? new ItemFieldValue(field, item, null);
            Fields.Add(field.Id, value.ToViewModel());
            FieldDefinitions.Add(field.ToViewModel());
        }
    }

    private void PopulateFields(Inventory inventory)
    {
        foreach (InventoryField field in inventory.Fields)
        {
            Fields.Add(field.Id, new FieldValueViewModel(field));
            FieldDefinitions.Add(field.ToViewModel());
        }
    }
}