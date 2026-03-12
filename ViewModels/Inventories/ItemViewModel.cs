using Humanizer;
using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.ViewModels.CustomId;

namespace ITask7.ViewModels.Inventories;

public class ItemViewModel
{
    public Guid Id { get; set; }
    public CustomIdModel CustomId { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? CreatedByUserName { get; set; }
    public Dictionary<Guid , FieldValueViewModel> FieldValues { get; set; } = new();
    public List<FieldDefinitionViewModel> FieldDefinitions { get; set; } = new();
    public uint RowVersion { get; set; }
    public uint InventoryRowVersion { get; set; }
    public Guid InventoryId { get; set; }
    public string CreatedAtString => CreatedAt.Humanize();
    
    public string CustomIdString() => CustomId.ToPrintString();

    public ItemViewModel(){}
    
    public ItemViewModel(Inventory inventory)
    {
        Id = Guid.Empty;
        CustomId = new CustomIdModel(inventory);
        InventoryId = inventory.Id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        InventoryRowVersion = inventory.RowVersion;
        CreatedByUserName = "none";
        PopulateFields(inventory);
    }

    public ItemViewModel(Item item)
    {
        Id = item.Id;
        CustomId = new CustomIdModel(item);
        CreatedByUserName = item.Creator?.UserName ?? "creator not found";
        CreatedAt = item.CreatedAt;
        UpdatedAt = item.UpdatedAt;
        InventoryId = item.InventoryId;
        RowVersion = item.RowVersion;
        InventoryRowVersion = item.Inventory.RowVersion;
        foreach (InventoryField field in item.Inventory.Fields)
        {
            ItemFieldValue value = item.TryGetValue(field.Id) ?? new ItemFieldValue(field, item, null);
            FieldValues.Add(field.Id, value.ToViewModel());
            FieldDefinitions.Add(field.ToViewModel());
        }
    }

    private void PopulateFields(Inventory inventory)
    {
        foreach (InventoryField field in inventory.Fields)
        {
            FieldValues.Add(field.Id, new FieldValueViewModel(field));
            FieldDefinitions.Add(field.ToViewModel());
        }
    }
}