namespace ITask7.Models.Inventories;

public class ItemFieldValue
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public Guid FieldId { get; set; }
    
    public string ValueText { get; set; }
    public decimal? ValueNumeric { get; set; }
    public bool? ValueBoolean { get; set; }
    public string ValueDocumentUrl { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
   
    public Item Item { get; set; }
    public InventoryField Field { get; set; }
    
    public object GetValue()
    {
        return Field?.FieldType switch
        {
            FieldType.SingleLine or FieldType.MultiLine => ValueText,
            FieldType.Numeric => ValueNumeric,
            FieldType.Boolean => ValueBoolean,
            FieldType.Document => ValueDocumentUrl,
            _ => null
        };
    }
}