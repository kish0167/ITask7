using ITask7.ViewModels.Inventories;

namespace ITask7.Models.Inventories;

public class InventoryField : IVersionedEntity, IInventoryChild
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; }
    
    public string Name { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public FieldType FieldType { get; set; }
    public bool IsRequired { get; set; }
    public bool DisplayInTable { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; }
    public uint RowVersion { get; set; }

    public Inventory Inventory { get; set; }
    public ICollection<ItemFieldValue> Values { get; set; } = new List<ItemFieldValue>();

    public InventoryField(){}
    
    public InventoryField(FieldDefinitionViewModel model, Inventory inventory)
    {
        Id = Guid.NewGuid();
        InventoryId = inventory.Id;
        Title = model.Title;
        Name = Title;
        FieldType = model.Type;
        Description = model.Description;
        CreatedAt = DateTime.UtcNow;
        DisplayInTable = model.DisplayInTable;
        IsRequired = model.IsRequired;
        SortOrder = inventory.Fields.Any()
            ? inventory.Fields.Select(f => f.SortOrder).ToList().Max() + 1
            : 1;
        Inventory = inventory;
    }
    
    public FieldDefinitionViewModel ToViewModel()
    {
        return new FieldDefinitionViewModel(this);
    }

    public void Edit(FieldDefinitionViewModel model)
    {
        Title = model.Title;
        Name = model.Title;
        Description = model.Description;
        DisplayInTable = model.DisplayInTable;
        SortOrder = model.SortOrder;
        IsRequired = model.IsRequired;
    }
}