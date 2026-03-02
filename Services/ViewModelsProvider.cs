using System.Diagnostics;
using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.ViewModels.Inventories;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class ViewModelsProvider(DbApiService dbApiService)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    public async Task<InventoryViewModel> GetInventory(Guid inventoryId)
    {
        Inventory inventory = await _dbApiService.GetInventory(inventoryId);
        InventoryViewModel viewModel = InventoryViewModelFromInventory(inventory);
        return viewModel;
    }

    private InventoryViewModel InventoryViewModelFromInventory(Inventory inventory)
    {
        return new InventoryViewModel()
        {
            Id = inventory.Id,
            Name = inventory.Name,
            Description = inventory.Description,
            Fields = GetFields(inventory),
            Items = GetItems(inventory)
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
            items.Add(GetItemViewModel(item, inventory));
        }
        return items;
    }

    private ItemViewModel GetItemViewModel(Item item, Inventory inventory)
    {
        ItemViewModel viewModel = ItemViewModelFromItem(item);
        foreach (ItemFieldValue value in item.FieldValues)  
        {
            viewModel.Fields.Add(value.Field.Id, FieldValueViewModelFromItemFieldValue(value));
        }
        return viewModel;
    }

    private ItemViewModel ItemViewModelFromItem(Item item)
    {
        return new ItemViewModel()
        {
            Id = item.Id,
            CustomId = item.CustomId,
            CreatedByUserName = item.Inventory.Creator?.UserName ?? "creator not found",
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };
    }
    
    private FieldValueViewModel FieldValueViewModelFromItemFieldValue(ItemFieldValue value)
    {
        FieldValueViewModel viewModel = new();
        viewModel.Type = value.Field.FieldType;
        switch (viewModel.Type)
        {
            case FieldType.Boolean:
                viewModel.Value = value.ValueBoolean;
                break;
            case FieldType.Numeric:
                viewModel.Value = value.ValueNumeric;
                break;
            case FieldType.MultiLine:
                viewModel.Value = value.ValueText;
                break;
            case FieldType.SingleLine:
                viewModel.Value = value.ValueText;
                break;
            case FieldType.Document:
                viewModel.Value = value.ValueDocumentUrl;
                break;
            default: 
                viewModel.Value = "error";
                break;
        }
        return viewModel;
    }
}