using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services.DbApi.Inventories;

public interface IInventoryRepository
{
    Task<Inventory?> GetByIdAsync(Guid id, bool tracking = false);
    Task<Inventory?> GetDetailedAsync(Guid id);
    Task<Inventory?> GetWithAccessesAsync(Guid id);
    Task<Inventory?> GetWithFieldsAsync(Guid id);
    Task<List<Inventory>> GetLatestAsync(int count);
    Task<List<Inventory>> GetPopularAsync(int count);
    Task<List<Inventory>> GetAllPublicAsync();
    Task<List<Inventory>> GetAllAsync();
    Task<bool> ExistsAsync(Guid id);
    Task<Guid?> CreateAsync(InventoryViewModel model, ApplicationUser creator);
    Task<bool> UpdateAsync(Inventory inventory);
    Task<bool> DeleteAsync(Guid id);
}