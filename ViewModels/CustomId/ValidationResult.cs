namespace ITask7.ViewModels.CustomId;

public class ValidationResult
{
    public string? Preview { get; set; }
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
}