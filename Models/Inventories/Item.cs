using Humanizer;
using ITask7.Services;
using ITask7.ViewModels.Inventories;
using ITask7.Models.CustomId;
using ITask7.Models.Users;
using ITask7.ViewModels.CustomId;

namespace ITask7.Models.Inventories;

public class Item : IVersionedEntity ,IInventoryChild
{
    public Guid Id { get; set; }
    public string CustomId { get; set; }
    public int SequentialNumber { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid InventoryId { get; set; }
    public uint RowVersion { get; set; }
    
    public ApplicationUser? Creator { get; set; }
    public Inventory? Inventory { get; set; }
    public ICollection<ItemFieldValue> FieldValues { get; set; } = new List<ItemFieldValue>();
    
    public Item(){}

    public Item(Inventory inventory, ApplicationUser user)
    {
        SequentialNumber = inventory.Sequential++;
        CustomId = new CustomIdModel(inventory).ToStorageString();
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
    
    private void AddNewValue(InventoryField field, object? value)
    {
        ItemFieldValue fieldValue = new ItemFieldValue(field, this, value);
        fieldValue.SetValue(value);
        FieldValues.Add(fieldValue);
    }

    public ItemViewModel ToViewModel()
    {
        return new ItemViewModel(this);
    }
    
    public void Edit(ItemViewModel viewModel)
    {
        if (Inventory == null) return;
        UpdatedAt = DateTime.UtcNow;
        viewModel.CustomId.InjectSequential(SequentialNumber);
        CustomId = viewModel.CustomId.ToStorageString();
        RowVersion = viewModel.RowVersion;
        Inventory.RowVersion = viewModel.InventoryRowVersion;
        foreach (InventoryField field in Inventory.Fields)
        {
            SetFieldValue(field, viewModel.FieldValues[field.Id].Value);
        }
    }
    
    private void SetFieldValue(InventoryField field, object? value)
    {
        foreach (ItemFieldValue fieldValue in FieldValues)
        {
            if (fieldValue.FieldId != field.Id) continue;
            fieldValue.SetValue(value);
            return;
        }

        AddNewValue(field, value);
    }

    
    public ItemFieldValue? TryGetValue(Guid fieldId)
    {
        return FieldValues.FirstOrDefault(v => v.Field.Id == fieldId);
    }
}