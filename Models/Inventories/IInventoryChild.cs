namespace ITask7.Models.Inventories;

public interface IInventoryChild
{
    Guid InventoryId { get; set; }
    Inventory Inventory { get; set; }
}