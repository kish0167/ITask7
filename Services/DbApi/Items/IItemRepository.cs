using ITask7.Models.Inventories;
using ITask7.Models.Users;

namespace ITask7.Services.DbApi.Items;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id);
    Task<Item?> GetByIdWithInventoryAsync(Guid id);
    Task<Item?> CreateAsync(Inventory inventory, ApplicationUser user);
    Task<bool> DeleteAsync(List<Guid> ids);
    Task<bool> SaveAsync(Item item);
    Task<bool> CustomIdExistsAsync(Guid inventoryId, string customId, Guid? excludeId = null);
}