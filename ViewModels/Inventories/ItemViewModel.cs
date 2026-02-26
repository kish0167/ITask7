namespace ITask7.ViewModels.Inventories;

public class ItemViewModel
{
    public Guid Id { get; set; }
    public string CustomId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string CreatedByUserName { get; set; }
    public Dictionary<Guid, FieldValueViewModel> Fields { get; set; }
}