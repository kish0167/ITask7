using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Chat;

public class ChatViewModel
{
    public Guid InventoryId { get; init; }
    public string CurrentUserName {get; set; }
    public List<MessageViewModel> Messages { get; init; } = new();

    public ChatViewModel(Inventory inventory)
    {
        InventoryId = inventory.Id;
        CurrentUserName = "undefined";
        Messages = inventory.Messages.Select(m => m.ToViewModel()).ToList();
    }
}