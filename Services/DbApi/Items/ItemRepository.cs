using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ITask7.Services.DbApi.Items;

public class ItemRepository(ApplicationDbContext dbContext)
    : InventoryChildRepository<Item>(dbContext), IItemRepository
{
    public async Task<Item?> GetByIdAsync(Guid id)
    {
        return await DbContext.Items
            .Where(i => i.Id == id)
            .Include(i => i.Inventory)
            .ThenInclude(inventory => inventory.Fields)
            .Include(i => i.Creator)
            .Include(i => i.FieldValues)
            .ThenInclude(v => v.Field)
            .FirstOrDefaultAsync();
    }
    
    public async Task<Item?> GetByIdWithInventoryAsync(Guid id)
    {
        return await DbContext.Items
            .Where(i => i.Id == id)
            .Include(i => i.Inventory)
            .FirstOrDefaultAsync();
    }

    public async Task<Item?> CreateAsync(Inventory inventory, ApplicationUser user)
    {
        Item item = new Item(inventory, user);
        await DbContext.Items.AddAsync(item);
        await DbContext.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteAsync(List<Guid> ids)
    {
        if (ids.Count == 0) return false;
        List<Item> items = await DbContext.Items
            .Where(i => ids.Contains(i.Id))
            .ToListAsync();
        if (items.Count == 0) return false;
        DbContext.Items.RemoveRange(items);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> SaveAsync(Item item)
    {
        return await SaveWithHierarchicalLockAsync(item);
    }

    public async Task<bool> CustomIdExistsAsync(Guid inventoryId, string customId, Guid? excludeId = null)
    {
        IQueryable<Item> query = DbContext.Items
            .Where(i => i.InventoryId == inventoryId && i.CustomId == customId);
        if (excludeId.HasValue)
            query = query.Where(i => i.Id != excludeId.Value);
        return await query.AnyAsync();
    }
}