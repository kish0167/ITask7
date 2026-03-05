using ITask7.Users;

namespace ITask7.Models.Inventories;

public class Item
{
    public Guid Id { get; set; }
    public string CustomId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid InventoryId { get; set; }
    public ApplicationUser? Creator { get; set; }
    public Inventory Inventory { get; set; }
    public ICollection<ItemFieldValue> FieldValues { get; set; } = new List<ItemFieldValue>();
}