namespace ITask7.Models.Inventories;

public class Item
{
    public Guid Id { get; set; }
    public Guid InventoryId { get; set; }
    
    public string CustomId { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public Inventory Inventory { get; set; }
    public ICollection<ItemFieldValue> FieldValues { get; set; } = new List<ItemFieldValue>();
}