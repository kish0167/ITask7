using ITask7.Models.Inventories;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Fields;

public interface IFieldRepository
{
    Task<InventoryField?> GetByIdAsync(Guid id);
    Task<InventoryField?> GetByIdWithInventoryAsync(Guid id);
    Task<Guid?> AddAsync(FieldDefinitionViewModel model, Inventory inventory);
    Task<Guid?> UpdateAsync(FieldDefinitionViewModel model);
    Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId);
}