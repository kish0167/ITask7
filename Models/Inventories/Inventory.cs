using ITask7.Users;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Models.Inventories;

public class Inventory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Custom id's


    public ApplicationUser? Creator { get; set; }
    public ICollection<InventoryField> Fields { get; set; } = new List<InventoryField>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
}