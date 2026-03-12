using ITask7.Data;
using ITask7.Models.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace ITask7.Services.DbApi;

public abstract class InventoryChildRepository<T> : BaseRepository<T>
    where T : class, IVersionedEntity, IInventoryChild
{
    protected InventoryChildRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    protected async Task<bool> SaveWithHierarchicalLockAsync(T entity)
    {
        using IDbContextTransaction transaction = await DbContext.Database.BeginTransactionAsync();
        
        try
        {
            Inventory? inventory = await DbContext.Inventories
                .Where(i => i.Id == entity.InventoryId)
                .FirstOrDefaultAsync();

            if (inventory == null) return false;
            
            EntityEntry<Inventory> inventoryEntry = DbContext.Entry(inventory);
            inventoryEntry.Property(i => i.RowVersion).OriginalValue = entity.Inventory.RowVersion;
            inventoryEntry.State = EntityState.Modified;
            
            EntityEntry<T> entityEntry = DbContext.Entry(entity);
            entityEntry.Property(e => e.RowVersion).OriginalValue = entity.RowVersion;

            await DbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}