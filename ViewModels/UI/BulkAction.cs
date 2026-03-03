namespace ITask7.ViewModels.UI;

public class BulkAction
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string ButtonClass { get; set; } = "btn-outline-secondary";
    public string Endpoint { get; set; } = null!;
}