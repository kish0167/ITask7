using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.ViewModels.Chat;

namespace ITask7.Models.Chat;

public class InventoryMessage
{
    public Guid Id { set; get; }
    public Guid InventoryId { set; get; }
    public string? SenderId { set; get; }
    public string Text { set; get; }
    public DateTime CreatedAt { set; get; }
    
    public Inventory Inventory { set; get; }
    public ApplicationUser? Sender { set; get; }
    
    public InventoryMessage(){}
    
    public InventoryMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        Id = Guid.Empty;
        InventoryId = inventoryId;
        SenderId = sender.Id;
        Text = text;
        CreatedAt = DateTime.UtcNow;
    }

    public MessageViewModel ToViewModel()
    {
        return new MessageViewModel(this);
    }
}