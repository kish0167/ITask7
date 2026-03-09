using ITask7.Models.Chat;
using ITask7.Users;
using ITask7.ViewModels;
using ITask7.ViewModels.Inventories;
using Microsoft.AspNetCore.Identity;

namespace ITask7.Models.Inventories;

public class Inventory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? CreatorId { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CustomIdSchemaJson { get; set; }
    public int Sequential { get; set; }
    
    public ApplicationUser? Creator { get; set; }
    public ICollection<InventoryField> Fields { get; set; } = new List<InventoryField>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
    public ICollection<InventoryAccess> Accesses { get; set; } = new List<InventoryAccess>();
    public ICollection<InventoryMessage> Messages { get; set; } = new List<InventoryMessage>();
    
    public Inventory(){}

    public Inventory(InventoryViewModel viewModel, ApplicationUser creator)
    {
        Id = Guid.NewGuid();
        Name = viewModel.Name;
        Description = viewModel.Description;
        CreatorId = creator.Id;
        IsPublic = viewModel.IsPublic;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Creator = creator;
    }
    public InventoryViewModel ToViewModel()
    {
        return new InventoryViewModel(this);
    }
    
    public bool UserIsCreator(ApplicationUser user)
    {
        return CreatorId == user.Id;
    }

    public bool UserHasWriteAccess(ApplicationUser user)
    {
        if (IsPublic) return true;
        if (UserIsCreator(user)) return true;
        return Accesses.Any(a => a.UserId == user.Id);
    }
}