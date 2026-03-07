using Humanizer;
using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class ItemViewModel
{
    public Guid Id { get; set; }
    public string CustomId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? CreatedByUserName { get; set; }
    public Dictionary<Guid , FieldValueViewModel> Fields { get; set; } = new();
    public List<FieldDefinitionViewModel> FieldDefinitions { get; set; } = new();
    public Guid InventoryId { get; set; }
    public string CreatedAtString => CreatedAt.Humanize();

    public void PopulateFields(Inventory inventory)
    {
        foreach (InventoryField field in inventory.Fields)
        {
            Fields.Add(field.Id, new FieldValueViewModel(field));
            FieldDefinitions.Add(field.ToViewModel());
        }
    }
}