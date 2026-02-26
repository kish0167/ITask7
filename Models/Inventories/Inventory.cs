namespace ITask7.Models.Inventories;

public class Inventory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Custom id's
    
    public ICollection<InventoryField> Fields { get; set; } = new List<InventoryField>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
}