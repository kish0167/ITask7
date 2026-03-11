using ITask7.Data;
using ITask7.Models.Inventories;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services.DbApi;

public abstract class BaseRepository<T> where T : class, IVersionedEntity
{
    protected readonly ApplicationDbContext DbContext;
    
    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    protected async Task<bool> SaveWithOptimisticLockAsync(T entity)
    {
        try
        {
            DbContext.Entry(entity).Property(e => e.RowVersion).OriginalValue = entity.RowVersion;
            await DbContext.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }
}