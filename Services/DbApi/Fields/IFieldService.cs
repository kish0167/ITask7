using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Fields;

public interface IFieldService
{
    Task<Guid?> AddAsync(FieldDefinitionViewModel model, Guid inventoryId);
    Task<Guid?> UpdateAsync(FieldDefinitionViewModel model);
    Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId);
}