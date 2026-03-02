using System.Diagnostics;
using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.ViewModels.Inventories;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class ViewModelsProvider(DbApiService dbApiService)
{
    private readonly DbApiService _dbApiService = dbApiService;
    
    public async Task<InventoryViewModel> GetInventoryViewModel(Guid inventoryId)
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
            IsPublic = inventory.IsPublic,
            Fields = GetFields(inventory),
            Items = GetItems(inventory),
            WriteAccessUsernames = inventory.Accesses.Select(a=>a.User.UserName ?? "noname").ToList()
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

    private ItemViewModel GetItemViewModel(Item item)
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
            UpdatedAt = item.UpdatedAt,
        };
    }
    
    private FieldValueViewModel FieldValueViewModelFromItemFieldValue(ItemFieldValue value)
    {
        FieldValueViewModel viewModel = new();
        viewModel.Type = value.Field.FieldType;
        viewModel.Value = value.GetValue();
        return viewModel;
    }
}