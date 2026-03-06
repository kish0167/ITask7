using System.Text.Json;
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
            viewModel.Fields.Add(value.Field.Id, FieldValueViewModelFromValue(value));
            viewModel.FieldDefinitions.Add(value.Field.ToViewModel());
        }
        return viewModel;
    }
    
    public ItemViewModel GetInventoryAlignedItemViewModel(Item item)
    {
        ItemViewModel viewModel = ItemViewModelFromItem(item);
        foreach (InventoryField field in item.Inventory.Fields)
        {
            ItemFieldValue value = TryGetValueFromItem(item, field.Id) ?? GetNewValue(field, item);
            viewModel.Fields.Add(field.Id, FieldValueViewModelFromValue(value));
            viewModel.FieldDefinitions.Add(field.ToViewModel());
        }
        return viewModel;
    }

    private ItemFieldValue GetNewValue(InventoryField field, Item item)
    {
        return new ItemFieldValue()
        {
            Id = Guid.NewGuid(),
            Field = field,
            FieldId = field.Id,
            Item = item,
            ItemId = item.Id
        };
    }

    public InventoryField GetNewField(FieldDefinitionViewModel fieldViewModel, Inventory inventory)
    {
        InventoryField field = new()
        {
            Id = Guid.NewGuid(),
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
            fields.Add(field.ToViewModel());
        }
        return fields;
    }
    
    private List<ItemViewModel> GetItems(Inventory inventory)
    {
        List<ItemViewModel> items = new();
        foreach (Item item in inventory.Items)
        {
            items.Add(GetInventoryAlignedItemViewModel(item));
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
            InventoryId = item.InventoryId
        };
    }
    
    private ItemFieldValue? TryGetValueFromItem(Item item, Guid fieldId)
    {
        return item.FieldValues.FirstOrDefault(v => v.Field.Id == fieldId);
    }
    
    private FieldValueViewModel FieldValueViewModelFromValue(ItemFieldValue value)
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
        foreach (InventoryField field in item.Inventory.Fields)
        {
            item.SetFieldValue(field, itemViewModel.Fields[field.Id].Value);
        }
    }

    public ItemViewModel GetEmptyItemViewModel(Inventory inventory)
    {
        ItemViewModel itemViewModel = new()
        {
            Id = Guid.Empty,
            InventoryId = inventory.Id,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            CreatedByUserName = "none",
            CustomId = "none"
        };
        itemViewModel.PopulateFields(inventory);
        return itemViewModel;
    }
}