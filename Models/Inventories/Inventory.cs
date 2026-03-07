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
    public string? CreatedBy { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // Custom id's


    public ApplicationUser? Creator { get; set; }
    public ICollection<InventoryField> Fields { get; set; } = new List<InventoryField>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
    public ICollection<InventoryAccess> Accesses { get; set; } = new List<InventoryAccess>();

    public InventoryViewModel ToViewModel()
    {
        return new InventoryViewModel()
        {
            Id = Id,
            Name = Name,
            Description = Description,
            CreatedBy = Creator?.UserName ?? "creator not found",
            IsPublic = IsPublic,
            Fields = GetFields(),
            Items = GetItems(),
            WriteAccessUsers = Accesses.Select(a=> a.User.ToViewModel()).ToList()
        };
    }
    
    private List<FieldDefinitionViewModel> GetFields()
    {
        List<FieldDefinitionViewModel> fields = new();
        foreach (InventoryField field in Fields)
        {
            fields.Add(field.ToViewModel());
        }
        return fields;
    }
    
    private List<ItemViewModel> GetItems()
    {
        List<ItemViewModel> items = new();
        foreach (Item item in Items)
        {
            items.Add(item.ToViewModel());
        }
        return items;
    }
    
    public bool UserIsCreator(ApplicationUser user)
    {
        return CreatedBy == user.Id;
    }

    public bool UserHasWriteAccess(ApplicationUser user)
    {
        if (IsPublic) return true;
        if (UserIsCreator(user)) return true;
        return Accesses.Any(a => a.UserId == user.Id);
    }
}