using ITask7.Models.Inventories;

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
    Task<bool> ExistsAsync(Guid id);
    Task<bool> UpdateAsync(Inventory inventory);
    Task<bool> DeleteAsync(Guid id);
}