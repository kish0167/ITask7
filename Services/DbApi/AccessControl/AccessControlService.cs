using System.Security.Claims;
using ITask7.Data;
using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.Services.DbApi.Inventories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services.DbApi.AccessControl;

public class AccessControlService(ApplicationDbContext dbContext, IInventoryRepository inventoryRepo, UserManager<ApplicationUser> userManager) : IAccessControlService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<bool> GrantAccessAsync(string username, Guid inventoryId)
    {
        ApplicationUser? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null) return false;
        
        if (!await _inventoryRepo.ExistsAsync(inventoryId)) return false;
        
        bool exists = await _dbContext.InventoryAccesses
            .AnyAsync(a => a.UserId == user.Id && a.InventoryId == inventoryId);
        if (exists) return false;
        
        InventoryAccess access = new InventoryAccess { UserId = user.Id, InventoryId = inventoryId };
        await _dbContext.InventoryAccesses.AddAsync(access);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RevokeAccessAsync(List<string> userIds, Guid inventoryId)
    {
        if (userIds.Count == 0) return false;
        List<InventoryAccess> accesses = await _dbContext.InventoryAccesses
            .Where(a => a.InventoryId == inventoryId && userIds.Contains(a.UserId))
            .ToListAsync();
        if (accesses.Count == 0) return false;
        _dbContext.InventoryAccesses.RemoveRange(accesses);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UserHasAdminAccess(ClaimsPrincipal claimsPrincipal)
    {
        ApplicationUser? user = await GetUser(claimsPrincipal);
        return (user?.IsAdmin ?? false) && !user.IsBlocked;
    }

    public async Task<bool> UserHasCreatorAccess(Guid inventoryId, ClaimsPrincipal claimsPrincipal)
    {
        ApplicationUser? user = await GetUser(claimsPrincipal);
        if (user == null || user.IsBlocked) return false;
        if (user.IsAdmin) return true;
        Inventory? inventory = await _inventoryRepo.GetWithAccessesAsync(inventoryId);
        return inventory?.UserIsCreator(user) ?? false;
    }

    public async Task<bool> UserHasWriteAccess(Guid inventoryId, ClaimsPrincipal claimsPrincipal)
    {
        ApplicationUser? user = await GetUser(claimsPrincipal);
        if (user == null || user.IsBlocked) return false;
        if (user.IsAdmin) return true;
        Inventory? inventory = await _inventoryRepo.GetWithAccessesAsync(inventoryId);
        return inventory?.UserHasWriteAccess(user) ?? false;
    }

    public async Task<bool> UserHasAuthorizedAccess(ClaimsPrincipal claimsPrincipal)
    {
        return !(await GetUser(claimsPrincipal))?.IsBlocked ?? false;
    }

    public async Task<bool> UserCanBeConnectedToSalesForce(ClaimsPrincipal claimsPrincipal)
    {
        ApplicationUser? user = await GetUser(claimsPrincipal);
        return user != null && user.SalesForceId == null;
    }

    private async Task<ApplicationUser?> GetUser(ClaimsPrincipal claimsPrincipal)
    {
        return await _userManager.GetUserAsync(claimsPrincipal);
    }
}