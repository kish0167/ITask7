using ITask7.Models.Users;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Items;

public interface IItemService
{
    Task<ItemViewModel?> GetByIdAsync(Guid id);
    Task<ItemViewModel?> GetEmptyAsync(Guid inventoryId);
    Task<Guid?> SaveAsync(ItemViewModel model, ApplicationUser user);
    Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId);
}