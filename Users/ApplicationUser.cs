using ITask7.Models.Inventories;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Users;

public class ApplicationUser : IdentityUser
{
    public ICollection<Inventory> CreatedInventories { get; set; } = new List<Inventory>();
}