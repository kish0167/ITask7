using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.Users;
using ITask7.ViewModels.Inventories;
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

    public async Task<string?> AddAccess(string username, Guid inventoryId)
    {
        ApplicationUser? user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null) return null;
        bool inventoryExists = await _dbContext.Inventories
            .AnyAsync(i => i.Id == inventoryId);
        if (!inventoryExists) return null; 
        bool accessExists = await _dbContext.InventoriesAccesses
            .AnyAsync(a => a.UserId == user.Id && a.InventoryId == inventoryId);
        if (accessExists) return null;
        var inventoryAccess = new InventoryAccess
        {
            UserId = user.Id,
            InventoryId = inventoryId
        };
        await _dbContext.InventoriesAccesses.AddAsync(inventoryAccess);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> RemoveAccesses(List<string> userIds, Guid inventoryId)
    {
        if (userIds == null || !userIds.Any())
            return false;
        
        List<InventoryAccess> accessesToRemove = await _dbContext.InventoriesAccesses
            .Where(a => a.InventoryId == inventoryId && userIds.Contains(a.UserId))
            .ToListAsync();

        if (!accessesToRemove.Any())
            return false;

        _dbContext.InventoriesAccesses.RemoveRange(accessesToRemove);
        int result = await _dbContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> EditProperties(InventoryViewModel model)
    {
        var inventory = await _dbContext.Inventories.FindAsync(model.Id);
        if (inventory == null) return false;
        
        if (inventory.Name != model.Name) inventory.Name = model.Name;
        if (inventory.Description != model.Description) inventory.Description = model.Description;
        if (inventory.IsPublic != model.IsPublic) inventory.IsPublic = model.IsPublic;
        
        try 
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public async Task<bool> RemoveFields(List<string> fieldsIds, Guid contextId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid?> AddField(FieldDefinitionViewModel field, Guid inventoryId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Guid?> EditField(FieldDefinitionViewModel field, Guid inventoryId)
    {
        throw new NotImplementedException();
    }
}