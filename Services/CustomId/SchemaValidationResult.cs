namespace ITask7.Services.CustomId;

public class SchemaValidationResult
{
    public string? Preview { get; set; }
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
}