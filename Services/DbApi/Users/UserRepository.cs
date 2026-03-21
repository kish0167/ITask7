using ITask7.Data;
using ITask7.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services.DbApi.Users;

public class UserRepository(ApplicationDbContext dbContext)
    : BaseRepository<ApplicationUser>(dbContext), IUserRepository
{
    public async Task<ApplicationUser?> GetByIdAsync(string id)
    {
        return await DbContext.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Include(u => u.CreatedInventories)
            .ThenInclude(i => i.Items)
            .Include(u => u.Accesses)
            .ThenInclude(a => a.Inventory)
            .ThenInclude(i => i.Items)
            .Include(u => u.Accesses)
            .ThenInclude(a => a.Inventory)
            .ThenInclude(i => i.Creator)
            .FirstOrDefaultAsync();
    }

    public async Task<ApplicationUser?> GetByUsernameAsync(string username)
    {
        return await DbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<List<ApplicationUser>> GetAllAsync()
    {
        return await DbContext.Users.ToListAsync();
    }

    public async Task<int> DeleteAsync(List<string> ids)
    {
        return await DbContext.Users
            .Where(u => ids.Contains(u.Id))
            .ExecuteDeleteAsync();
    }


    public async Task<int> BlockAsync(List<string> ids)
    {
        var users = await DbContext.Users
            .Where(u => ids.Contains(u.Id) && !u.IsBlocked)
            .ToListAsync();
            
        foreach (var user in users) user.Block();
        return await DbContext.SaveChangesAsync();
    }

    public async Task<int> UnblockAsync(List<string> ids)
    {
        var users = await DbContext.Users
            .Where(u => ids.Contains(u.Id) && u.IsBlocked)
            .ToListAsync();
            
        foreach (var user in users) user.UnBlock();
        return await DbContext.SaveChangesAsync();
    }

    public async Task<int> MakeAdminAsync(List<string> ids)
    {
        var users = await DbContext.Users
            .Where(u => ids.Contains(u.Id) && !u.IsAdmin)
            .ToListAsync();
            
        foreach (var user in users) user.MakeAdmin();
        return await DbContext.SaveChangesAsync();
    }

    public async Task<int> RemoveAdminAsync(List<string> ids)
    {
        var users = await DbContext.Users
            .Where(u => ids.Contains(u.Id) && u.IsAdmin)
            .ToListAsync();
            
        foreach (var user in users) user.DeAdmin();
        return await DbContext.SaveChangesAsync();
    }

    public async Task<bool> SetSalesForceId(string userId, string? salesForceId)
    {
        ApplicationUser? user = await DbContext.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();
        if (user == null) return false;
        user.SalesForceId = salesForceId;
        int result = await DbContext.SaveChangesAsync();
        return result > 0;
    }
}