using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.Users;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class DbApiService(ApplicationDbContext dbContext)
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    
    public async Task<Inventory> GetInventory(Guid inventoryId)
    {
        Inventory? inventory = await _dbContext.Inventories
            .AsNoTracking()
            .Where(i => i.Id == inventoryId)
            .Include(i => i.Fields.OrderBy(f => f.SortOrder))
            .Include(i => i.Items)
            .ThenInclude(item => item.FieldValues)
            .ThenInclude(value => value.Field)
            .Include(i => i.Creator)
            .Include(i => i.Accesses)
            .ThenInclude(access => access.User)
            .FirstOrDefaultAsync();
        return inventory ?? new Inventory();
    }

    public async Task<bool> AddAccess(string username, Guid inventoryId)
    {
        ApplicationUser? user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null) return false;
        bool inventoryExists = await _dbContext.Inventories
            .AnyAsync(i => i.Id == inventoryId);
        if (!inventoryExists) return false; 
        bool accessExists = await _dbContext.InventoriesAccesses
            .AnyAsync(a => a.UserId == user.Id && a.InventoryId == inventoryId);
        if (accessExists) return false;
        var inventoryAccess = new InventoryAccess
        {
            UserId = user.Id,
            InventoryId = inventoryId
        };
        await _dbContext.InventoriesAccesses.AddAsync(inventoryAccess);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}