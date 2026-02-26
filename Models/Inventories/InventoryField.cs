namespace ITask7.Models.Inventories;

public class InventoryField
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
    
    //public JsonDocument ValidationRules { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public Inventory Inventory { get; set; }
    public ICollection<ItemFieldValue> Values { get; set; } = new List<ItemFieldValue>();
}