using ITask7.Models.Inventories;
using ITask7.Services.DbApi.Inventories;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Fields;

public class FieldService(IFieldRepository fieldRepo, IInventoryRepository inventoryRepo) : IFieldService
{
    private readonly IFieldRepository _fieldRepo = fieldRepo;
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;

    public async Task<Guid?> AddAsync(FieldDefinitionViewModel model, Guid inventoryId)
    {
        Inventory? inventory = await _inventoryRepo.GetWithFieldsAsync(inventoryId);
        if (inventory == null) return null;
        return await _fieldRepo.AddAsync(model, inventory);
    }

    public async Task<Guid?> UpdateAsync(FieldDefinitionViewModel model)
    {
        return await _fieldRepo.UpdateAsync(model);
    }

    public async Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId)
    {
        return await _fieldRepo.DeleteAsync(ids, inventoryId);
    }
}