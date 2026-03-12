using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.ViewModels.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ITask7.Services.DbApi.Fields;

public class FieldRepository(ApplicationDbContext dbContext)
    : InventoryChildRepository<InventoryField>(dbContext), IFieldRepository
{
    public async Task<InventoryField?> GetByIdAsync(Guid id)
    {
        return await DbContext.InventoryFields
            .Where(f => f.Id == id)
            .Include(f => f.Inventory)
            .ThenInclude(i => i.Fields)
            .FirstOrDefaultAsync();
    }

    public async Task<InventoryField?> GetByIdWithInventoryAsync(Guid id)
    {
        return await DbContext.InventoryFields
            .Where(f => f.Id == id)
            .Include(f => f.Inventory)
            .FirstOrDefaultAsync();
    }

    public async Task<Guid?> AddAsync(FieldDefinitionViewModel model, Inventory inventory)
    {
        InventoryField field = new InventoryField(model, inventory);
        await DbContext.InventoryFields.AddAsync(field);
        await SaveWithHierarchicalLockAsync(field);
        return field.Id;
    }
    
    public async Task<Guid?> UpdateAsync(FieldDefinitionViewModel model)
    {
        InventoryField? field = await GetByIdAsync(model.Id);
        if (field == null) return null;
        field.Edit(model);
        bool success = await SaveWithHierarchicalLockAsync(field);
        return success ? field.Id : null;
    }

    public async Task<bool> DeleteAsync(List<Guid> ids, Guid inventoryId)
    {
        if (ids.Count == 0) return false;
        
        List<InventoryField> fields = await DbContext.InventoryFields
            .Where(f => ids.Contains(f.Id) && f.InventoryId == inventoryId)
            .ToListAsync();
            
        if (fields.Count == 0) return false;
        
        DbContext.InventoryFields.RemoveRange(fields);
        return await DbContext.SaveChangesAsync() > 0;
    }
}