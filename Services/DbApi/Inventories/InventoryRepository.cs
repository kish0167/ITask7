using ITask7.Data;
using ITask7.Models.Inventories;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services.DbApi.Inventories;

public class InventoryRepository(ApplicationDbContext dbContext)
    : BaseRepository<Inventory>(dbContext), IInventoryRepository
{
    public async Task<Inventory?> GetByIdAsync(Guid id, bool tracking = false)
    {
        IQueryable<Inventory> query = DbContext.Inventories.AsQueryable();
        if (!tracking) query = query.AsNoTracking();
        
        return await query
            .Include(i => i.Creator)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Inventory?> GetDetailedAsync(Guid id)
    {
        return await DbContext.Inventories
            .Where(i => i.Id == id)
            .Include(i => i.Fields.OrderBy(f => f.SortOrder))
            .Include(i => i.Items)
            .ThenInclude(item => item.FieldValues)
            .ThenInclude(value => value.Field)
            .Include(i => i.Items)
            .ThenInclude(item => item.Creator)
            .Include(i => i.Creator)
            .Include(i => i.Accesses)
            .ThenInclude(access => access.User)
            .Include(i => i.Messages)
            .FirstOrDefaultAsync();
    }

    public async Task<Inventory?> GetWithAccessesAsync(Guid id)
    {
        return await DbContext.Inventories
            .AsNoTracking()
            .Where(i => i.Id == id)
            .Include(i => i.Accesses)
            .FirstOrDefaultAsync();
    }

    public async Task<Inventory?> GetWithFieldsAsync(Guid id)
    {
        return await DbContext.Inventories
            .Include(i => i.Fields)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<Inventory>> GetLatestAsync(int count)
    {
        return await DbContext.Inventories
            .AsNoTracking()
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .OrderByDescending(i => i.UpdatedAt)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<Inventory>> GetPopularAsync(int count)
    {
        return await DbContext.Inventories
            .AsNoTracking()
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .OrderByDescending(i => i.Items.Count)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<Inventory>> GetAllPublicAsync()
    {
        return await DbContext.Inventories
            .AsNoTracking()
            .Where(i => i.IsPublic)
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await DbContext.Inventories.AnyAsync(i => i.Id == id);
    }

    public async Task<bool> UpdateAsync(Inventory inventory)
    {
        DbContext.Inventories.Update(inventory);
        return await SaveWithOptimisticLockAsync(inventory);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        Inventory? inventory = await DbContext.Inventories.FindAsync(id);
        if (inventory == null) return false;
        DbContext.Inventories.Remove(inventory);
        return await DbContext.SaveChangesAsync() > 0;
    }
}