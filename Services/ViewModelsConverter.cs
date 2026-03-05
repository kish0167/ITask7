using System.Text.RegularExpressions;
using ITask7.Models.Inventories;
using ITask7.Users;
using ITask7.ViewModels;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services;

public class ViewModelsConverter()
{
    public InventoryViewModel GetInventoryViewModel(Inventory inventory)
    {
        InventoryViewModel viewModel = InventoryViewModelFromInventory(inventory);
        return viewModel;
    }
    
    public ItemViewModel GetItemViewModel(Item item)
    {
        ItemViewModel viewModel = ItemViewModelFromItem(item);
        foreach (ItemFieldValue value in item.FieldValues)  
        {
            viewModel.Fields.Add(value.Field.Id, FieldValueViewModelFromItemFieldValue(value));
            viewModel.FieldDefinitions.Add(FieldViewModelFromField(value.Field));
        }
        return viewModel;
    }
    
    public InventoryField GetNewField(FieldDefinitionViewModel fieldViewModel, Inventory inventory)
    {
        InventoryField field = new()
        {
            Id = new Guid(),
            InventoryId = inventory.Id,
            Title = fieldViewModel.Title,
            Name = Regex.Replace(fieldViewModel.Title, @"(\B[A-Z])", "_$1").ToLower(),
            FieldType = fieldViewModel.Type,
            Description = fieldViewModel.Description,
            CreatedAt = DateTime.UtcNow,
            DisplayInTable = fieldViewModel.DisplayInTable,
            IsRequired = fieldViewModel.IsRequired,
            SortOrder = inventory.Fields.Select(f=>f.SortOrder).ToList().Max() + 1
        };
        return field;
    }

    public void EditFieldProperties(InventoryField field, FieldDefinitionViewModel fieldViewModel)
    {
        field.Title = fieldViewModel.Title;
        field.Name = TitleToName(fieldViewModel.Title);
        field.Description = fieldViewModel.Description;
        field.DisplayInTable = fieldViewModel.DisplayInTable;
        field.IsRequired = fieldViewModel.IsRequired;
    }

    private InventoryViewModel InventoryViewModelFromInventory(Inventory inventory)
    {
        return new InventoryViewModel()
        {
            Id = inventory.Id,
            Name = inventory.Name,
            Description = inventory.Description,
            CreatedBy = inventory.Creator?.UserName ?? "creator not found",
            IsPublic = inventory.IsPublic,
            Fields = GetFields(inventory),
            Items = GetItems(inventory),
            WriteAccessUsers = inventory.Accesses.Select(a=> UserViewModelFromUser(a.User)).ToList()
        };
    }

    private List<FieldDefinitionViewModel> GetFields(Inventory inventory)
    {
        List<FieldDefinitionViewModel> fields = new();
        foreach (InventoryField field in inventory.Fields)
        {
            fields.Add(FieldViewModelFromField(field));
        }
        return fields;
    }

    private static FieldDefinitionViewModel FieldViewModelFromField(InventoryField field)
    {
        return new ()
        {
            Id = field.Id,
            Title = field.Title,
            Description = field.Description,
            DisplayInTable = field.DisplayInTable,
            IsRequired = field.IsRequired,
            SortOrder = field.SortOrder,
            Type = field.FieldType
        };
    }

    private List<ItemViewModel> GetItems(Inventory inventory)
    {
        List<ItemViewModel> items = new();
        foreach (Item item in inventory.Items)
        {
            items.Add(GetItemViewModel(item));
        }
        return items;
    }

    private ItemViewModel ItemViewModelFromItem(Item item)
    {
        return new ItemViewModel()
        {
            Id = item.Id,
            CustomId = item.CustomId,
            CreatedByUserName = item.Creator?.UserName ?? "creator not found",
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
        };
    }
    
    private FieldValueViewModel FieldValueViewModelFromItemFieldValue(ItemFieldValue value)
    {
        FieldValueViewModel viewModel = new()
        {
            Type = value.Field.FieldType,
            Value = value.GetValue()
        };
        return viewModel;
    }

    private UserViewModel UserViewModelFromUser(ApplicationUser user)
    {
        return new UserViewModel()
        {
            Id = user.Id,
            Email = user.Email
        };
    }
    
    private string TitleToName(string title)
    {
        return Regex.Replace(title, @"(\B[A-Z])", "_$1").ToLower();
    }

    public void EditItem(Item item, ItemViewModel itemViewModel)
    {
        item.UpdatedAt = DateTime.UtcNow;
        item.CustomId = itemViewModel.CustomId;
        foreach (ItemFieldValue value in item.FieldValues)
        {
            UpdateValue(value, itemViewModel.Fields[value.Id]);
        }
    }

    private void UpdateValue(ItemFieldValue value, FieldValueViewModel valueViewModel)
    {
        switch (value.Field.FieldType)
        {
            case FieldType.SingleLine or FieldType.MultiLine or FieldType.Document:
            {
                value.ValueText = valueViewModel.Value?.ToString();
                break;
            }
            case FieldType.Numeric:
            {
                value.ValueNumeric = valueViewModel.Value switch
                {
                    null => null,
                    decimal d => d,
                    double d => (decimal)d,
                    float f => (decimal)f,
                    int i => i,
                    long l => l,
                    string s when decimal.TryParse(s, out var result) => result,
                    _ => throw new InvalidCastException($"Cannot convert {valueViewModel.Value?.GetType()} to decimal")
                };
                break;
            }

            case FieldType.Boolean:
            {
                value.ValueBoolean = valueViewModel.Value switch
                {
                    null => null,
                    bool b => b,
                    int i => i != 0,
                    long l => l != 0,
                    double d => d != 0 && !double.IsNaN(d),
                    string s => bool.TryParse(s, out var result) ? result : null,
                    _ => throw new InvalidCastException($"Cannot convert {valueViewModel.Value?.GetType()} to bool")
                };
                break;
            }
        }
    }
}