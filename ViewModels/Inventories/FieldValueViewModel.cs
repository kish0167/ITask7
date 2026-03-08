using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class FieldValueViewModel
{
    public FieldType Type { get; set; }
    public object? Value { get; set; }
    public string DisplayValue => Value?.ToString() ?? "";
    
    public FieldValueViewModel(){}
    
    public FieldValueViewModel(ItemFieldValue value)
    {
        Type = value.Field.FieldType;
        Value = value.GetValue();
    }

    public FieldValueViewModel(InventoryField field)
    {
        Type = field.FieldType;
        Value = null;
    }

    public FieldValueViewModel(FieldDefinitionViewModel fieldDef)
    {
        Type = fieldDef.Type;
        Value = null;
    }
}