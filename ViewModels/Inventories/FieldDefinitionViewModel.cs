using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class FieldDefinitionViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public FieldType Type { get; set; }
    public int SortOrder { get; set; }
    public bool DisplayInTable { get; set; }
    public bool IsRequired { get; set; }
}