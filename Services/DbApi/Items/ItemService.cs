using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.Services.DbApi.FieldValues;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Items;

public class ItemService(IItemRepository itemRepo, IInventoryRepository inventoryRepo, IItemFieldValueRepository valueRepo)
    : IItemService
{
    private readonly IItemRepository _itemRepo = itemRepo;
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly IItemFieldValueRepository _valueRepo = valueRepo;

    public async Task<ItemViewModel?> GetByIdAsync(Guid id)
    {
        Item? item = await _itemRepo.GetByIdAsync(id);
        return item?.ToViewModel();
    }

    public async Task<ItemViewModel?> GetEmptyAsync(Guid inventoryId)
    {
        Inventory? inventory = await _inventoryRepo.GetWithFieldsAsync(inventoryId);
        return inventory == null ? null : new ItemViewModel(inventory);
    }

    public async Task<Guid?> SaveAsync(ItemViewModel model, ApplicationUser user)
    {
        if (!model.CustomId.Validate().IsValid) return null;
        Item? item;
        bool isNew = false;
        
        if (model.Id == Guid.Empty)
        {
            Inventory? inventory = await _inventoryRepo.GetWithFieldsAsync(model.InventoryId);
            if (inventory == null) return null;
            item = await _itemRepo.CreateAsync(inventory, user);
            if (item == null) return null;
            isNew = true;
        }
        else
        {
            item = await _itemRepo.GetByIdWithInventoryAsync(model.Id);
            if (item == null) return null;
        }

        if (!isNew && item.CustomId != model.CustomId.ToStorageString())
        {
            if (await _itemRepo.CustomIdExistsAsync(item.InventoryId, model.CustomId.ToStorageString(), item.Id))
                return null;
        }
        
        item.Edit(model);
        
        
        bool success = await _itemRepo.SaveAsync(item);
        
        if (!success)
        {
            return null;
        }
        
        return item.Id;
        
        foreach (KeyValuePair<Guid, FieldValueViewModel> valueViewModel in model.FieldValues)
        {
            ItemFieldValue? value = item.FieldValues.FirstOrDefault(v => v.FieldId == valueViewModel.Key);
            if (value == null) continue;
            value.SetValue(valueViewModel.Value.Value);
            await _valueRepo.SaveAsync(value);
        }
        
        return item.Id;
    }

    public async Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId)
    {
        if (!await _inventoryRepo.ExistsAsync(inventoryId))
            return false;
        return await _itemRepo.DeleteAsync(ids);
    }
}