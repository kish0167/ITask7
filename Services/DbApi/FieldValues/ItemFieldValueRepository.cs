using ITask7.Data;
using ITask7.Models.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ITask7.Services.DbApi.FieldValues;

public class ItemFieldValueRepository(ApplicationDbContext dbContext) : IItemFieldValueRepository
{
    public async Task<bool> SaveAsync(ItemFieldValue value)
    {
        EntityEntry<ItemFieldValue> entry = dbContext.Entry(value);
        
        if (entry.State == EntityState.Detached)
            await dbContext.ItemFieldValues.AddAsync(value);
        else
            dbContext.ItemFieldValues.Update(value);
            
        await dbContext.SaveChangesAsync();
        return true;
    }
}