using ITask7.Models.Inventories;

namespace ITask7.Services.DbApi.FieldValues;

public interface IItemFieldValueRepository
{
    Task<bool> SaveAsync(ItemFieldValue value);
}