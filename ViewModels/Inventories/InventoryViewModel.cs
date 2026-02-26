using ITask7.Models.Inventories;

namespace ITask7.ViewModels.Inventories;

public class InventoryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<FieldDefinitionViewModel> Fields { get; set; }
    public List<ItemViewModel> Items { get; set; }

    public InventoryViewModel()
    {
        Id = new Guid();
        Name = "This is test inventory";
        Description = "nothing here to describe - only test purpose of this inventory";
        Fields = new List<FieldDefinitionViewModel>();
        Guid fieldGuid = new Guid();
        Fields.Add(new FieldDefinitionViewModel()
        {
            Title = "Test field",
            Description = "only for testing purposes",
            DisplayInTable = true,
            IsRequired = true,
            Id = fieldGuid,
            SortOrder = 0,
            Type = FieldType.Numeric
        });
        Items = new List<ItemViewModel>();
        Items.Add(new ItemViewModel()
        {
            CreatedAt = DateTime.UtcNow,
            CreatedByUserName = "God himself",
            CustomId = "i'm unique, trust me",
            Fields = new Dictionary<Guid, FieldValueViewModel>(),
            Id = new Guid(),
            UpdatedAt = DateTime.UtcNow
        });
        Items[0].Fields.Add(fieldGuid, new FieldValueViewModel()
        {
            Value = 147,
            Type = FieldType.Numeric
        });
    }
}