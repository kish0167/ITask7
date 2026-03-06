using ITask7.Services;
using ITask7.Users;

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
}