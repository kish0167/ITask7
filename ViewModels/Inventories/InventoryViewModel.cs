using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.ViewModels.Chat;

namespace ITask7.ViewModels.Inventories;

public class InventoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedBy { get; set; }
    public bool IsPublic { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<FieldDefinitionViewModel> Fields { get; set; } = new();
    public List<ItemViewModel> Items { get; set; } = new();
    public List<UserViewModel> WriteAccessUsers { get; set; } = new();
    public ChatViewModel ChatViewModel { get; set; }
    public CustomIdSchema CustomIdSchema { get; set; }
    
    public InventoryViewModel(){}
    
    public InventoryViewModel(Inventory inventory)
    {
        Id = inventory.Id;
        Name = inventory.Name;
        Description = inventory.Description;
        CreatedBy = inventory.Creator?.UserName ?? "creator not found";
        IsPublic = inventory.IsPublic;
        UpdatedAt = inventory.UpdatedAt;
        Fields = inventory.Fields.Select(field => field.ToViewModel()).ToList();
        Items = inventory.Items.Select(item => item.ToViewModel()).ToList();
        WriteAccessUsers = inventory.Accesses.Select(a => a.User.ToViewModel()).ToList();
        ChatViewModel = new ChatViewModel(inventory);
        CustomIdSchema = new CustomIdSchema(inventory.CustomIdSchemaJson);
    }
}