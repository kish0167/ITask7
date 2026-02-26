using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class FieldValueViewModel
{
    public FieldType Type { get; set; }
    public object Value { get; set; }
    public string DisplayValue => Value.ToString() ?? "";
}