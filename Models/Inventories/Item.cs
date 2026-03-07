using ITask7.Services;
using ITask7.Users;
using ITask7.ViewModels.Inventories;

namespace ITask7.Models.Inventories;

public class Item
{
    public Guid Id { get; set; }
    public string CustomId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid InventoryId { get; set; }
    public ApplicationUser? Creator { get; set; }
    public Inventory Inventory { get; set; }
    public ICollection<ItemFieldValue> FieldValues { get; set; } = new List<ItemFieldValue>();
    
    public Item(){}

    public Item(Inventory inventory, ApplicationUser user)
    {
        CustomId = "none";
        CreatedBy = user.Id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        InventoryId = inventory.Id;
        Inventory = inventory;
        foreach (InventoryField field in inventory.Fields)
        {
            AddNewValue(field, null);
        }
        inventory.Items.Add(this);
    }

    public void SetFieldValue(InventoryField field, object? value)
    {
        foreach (ItemFieldValue fieldValue in FieldValues)
        {
            if (fieldValue.FieldId != field.Id) continue;
            fieldValue.SetValue(value);
            return;
        }

        AddNewValue(field, value);
    }

    private void AddNewValue(InventoryField field, object? value)
    {
        ItemFieldValue fieldValue = new ItemFieldValue(field, this, value);
        fieldValue.SetValue(value);
        FieldValues.Add(fieldValue);
    }

    public ItemViewModel ToViewModel()
    {
        ItemViewModel viewModel = new()
        {
            Id = Id,
            CustomId = CustomId,
            CreatedByUserName = Creator?.UserName ?? "creator not found",
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            InventoryId = InventoryId
        };
        foreach (InventoryField field in Inventory.Fields)
        {
            ItemFieldValue value = TryGetValue(field.Id) ?? GetNewValue(field);
            viewModel.Fields.Add(field.Id, value.ToViewModel());
            viewModel.FieldDefinitions.Add(field.ToViewModel());
        }
        return viewModel;
    }
    
    private ItemFieldValue? TryGetValue(Guid fieldId)
    {
        return FieldValues.FirstOrDefault(v => v.Field.Id == fieldId);
    }
    
    private ItemFieldValue GetNewValue(InventoryField field)
    {
        return new ItemFieldValue()
        {
            Id = Guid.NewGuid(),
            Field = field,
            FieldId = field.Id,
            Item = this,
            ItemId = Id
        };
    }
}