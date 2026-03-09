using ITask7.Services;
using ITask7.Services.Helpers;
using ITask7.ViewModels.Inventories;

namespace ITask7.Models.Inventories;

public class ItemFieldValue
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public Guid FieldId { get; set; }
    
    public string? ValueText { get; set; }
    public decimal? ValueNumeric { get; set; }
    public bool? ValueBoolean { get; set; }
    // public string? ValueDocumentUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
   
    public Item Item { get; set; }
    public InventoryField Field { get; set; }
    
    public ItemFieldValue(){}

    public ItemFieldValue(InventoryField field, Item item, object? value)
    {
        ItemId = item.Id;
        FieldId = field.Id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Item = item;
        Field = field;
        SetValue(value);
    }

    public FieldValueViewModel ToViewModel()
    {
        return new FieldValueViewModel(this);
    }

    public object GetValue()
    {
        object? value = Field.FieldType switch
        {
            FieldType.SingleLine or FieldType.MultiLine or FieldType.Document => ValueText,
            FieldType.Numeric => ValueNumeric,
            FieldType.Boolean => ValueBoolean,
            _ => "Field type error"
        };
        return value ?? "no value";
    }

    public void SetValue(object? newValue)
    {
        switch (Field.FieldType)
        {
            case FieldType.SingleLine or FieldType.MultiLine or FieldType.Document:
            {
                ValueText = RawValueConverter.ConvertToString(newValue);
                break;
            }
            case FieldType.Numeric:
            {
                ValueNumeric = RawValueConverter.ConvertToDecimal(newValue);
                break;
            }
            case FieldType.Boolean:
            {
                ValueBoolean = RawValueConverter.ConvertToBool(newValue);
                break;
            }
        }
    }
}