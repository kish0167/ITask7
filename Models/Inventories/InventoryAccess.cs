using ApplicationUser = ITask7.Models.Users.ApplicationUser;

namespace ITask7.Models.Inventories;

public class InventoryAccess
{
    public Guid InventoryId { get; set; }
    public string UserId { get; set; }
    
    public ApplicationUser User { get; set; } = null!;
    public Inventory Inventory { get; set; } = null!;
}