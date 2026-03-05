using ITask7.Models.Inventories;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Users;

public class ApplicationUser : IdentityUser
{
    public ICollection<Inventory> CreatedInventories { get; set; } = new List<Inventory>();
    public ICollection<InventoryAccess> Accesses { get; set; } = new List<InventoryAccess>();
    
    public ICollection<Item> CreatedItems { get; set; } = new List<Item>();
}