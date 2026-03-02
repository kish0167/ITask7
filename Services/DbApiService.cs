using ITask7.Data;
using ITask7.Models.Inventories;
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
            .FirstOrDefaultAsync();
        return inventory ?? new Inventory();
    }
}