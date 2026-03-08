using ITask7.Models.Chat;

namespace ITask7.ViewModels.Chat;

public class MessageViewModel
{
    public string Text { get; set; }
    public string SenderName { get; set; }
    public DateTime SentAt { get; set; }
    
    public MessageViewModel(){}

    public MessageViewModel(InventoryMessage messge)
    {
        Text = messge.Text;
        SenderName = messge.Sender?.UserName ?? "deleted";
        SentAt = messge.CreatedAt;
    }
}