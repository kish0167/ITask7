using ITask7.Data;
using ITask7.Models.Chat;
using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.Users;
using ITask7.ViewModels;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;
using Microsoft.EntityFrameworkCore;

namespace ITask7.Services;

public class DbApiService(ApplicationDbContext dbContext, ViewModelsConverter viewModelsConverter)
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly ViewModelsConverter _viewModelsConverter = viewModelsConverter;

    public async Task<MainPageViewModel> GetMainPageViewModel()
    {
        MainPageViewModel viewModel = new();
        viewModel.LatestInventories = (await GetLatestInventories(viewModel.MaxLatestCount))
            .Select(i => i.ToViewModel()).ToList();
        viewModel.PopularInventories = (await GetPopularInventories(viewModel.MaxPopularCount))
            .Select(i => i.ToViewModel()).ToList();
        return viewModel;
    }

    public async Task<InventoryViewModel?> GetInventoryViewModel(Guid inventoryId)
    {
        Inventory? inventory = await GetInventoryDetailed(inventoryId);
        if (inventory == null) return null;
        return inventory.ToViewModel();
    }

    public async Task<ItemViewModel?> GetItemViewModel(Guid itemId)
    {
        Item? item = await GetItem(itemId);
        if (item == null) return null;
        return item.ToViewModel();
    }

    private async Task<Item?> CreateNewItem(Guid inventoryId, ApplicationUser user)
    {
        Inventory? inventory = await GetInventoryDetailed(inventoryId);
        if (inventory == null) return null;
        Item item = new Item(inventory, user);
        await _dbContext.Items.AddAsync(item);
        return item;
    }

    public async Task<ItemViewModel?> GetEmptyItemViewModel(Guid inventoryId)
    {
        Inventory? inventory = await GetInventoryDetailed(inventoryId);
        if (inventory == null) return null;
        return new ItemViewModel(inventory);
    }
    
    public async Task<List<UserViewModel>> GetAllUsersViewModels()
    {
        return await _dbContext.Users.Select(u => u.ToViewModel()).ToListAsync();
    }
    
    public async Task<bool> AddAccess(string username, Guid inventoryId)
    {
        ApplicationUser? user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null) return false;
        bool inventoryExists = await _dbContext.Inventories
            .AnyAsync(i => i.Id == inventoryId);
        if (!inventoryExists) return false;
        bool accessExists = await _dbContext.InventoryAccesses
            .AnyAsync(a => a.UserId == user.Id && a.InventoryId == inventoryId);
        if (accessExists) return false;
        var inventoryAccess = new InventoryAccess
        {
            UserId = user.Id,
            InventoryId = inventoryId
        };
        await _dbContext.InventoryAccesses.AddAsync(inventoryAccess);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveAccesses(List<string> userIds, Guid inventoryId)
    {
        if (!userIds.Any())
            return false;
        List<InventoryAccess> accessesToRemove = await _dbContext.InventoryAccesses
            .Where(a => a.InventoryId == inventoryId && userIds.Contains(a.UserId))
            .ToListAsync();
        if (!accessesToRemove.Any())
            return false;
        _dbContext.InventoryAccesses.RemoveRange(accessesToRemove);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> EditInventoryProperties(InventoryViewModel model)
    {
        Inventory? inventory = await _dbContext.Inventories.FindAsync(model.Id);
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

    public async Task<bool> RemoveFields(List<Guid> fieldsIds, Guid inventoryId)
    {
        if (!fieldsIds.Any())
            return false;
        List<InventoryField> fieldsToRemove = await _dbContext.InventoryFields
            .Where(f => fieldsIds.Contains(f.Id))
            .ToListAsync();
        if (!fieldsToRemove.Any())
            return false;
        _dbContext.InventoryFields.RemoveRange(fieldsToRemove);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> AddField(FieldDefinitionViewModel fieldViewModel, Guid inventoryId)
    {
        Inventory? inventory = await GetInventoryDetailed(inventoryId);
        if (inventory == null) return null;
        InventoryField field = _viewModelsConverter.GetNewField(fieldViewModel, inventory);
        await _dbContext.InventoryFields.AddAsync(field);
        await _dbContext.SaveChangesAsync();
        return field.Id;
    }

    public async Task<Guid?> EditFieldProperties(FieldDefinitionViewModel fieldViewModel, Guid inventoryId)
    {
        InventoryField field = await GetField(fieldViewModel.Id);
        _viewModelsConverter.EditFieldProperties(field, fieldViewModel);
        await _dbContext.SaveChangesAsync();
        return field.Id;
    }

    private async Task<Inventory?> GetInventoryDetailed(Guid inventoryId)
    {
        Inventory? inventory = await _dbContext.Inventories
            .Where(i => i.Id == inventoryId)
            .Include(i => i.Fields.OrderBy(f => f.SortOrder))
            .Include(i => i.Items)
            .ThenInclude(item => item.FieldValues)
            .ThenInclude(value => value.Field)
            .Include(i => i.Items)
            .ThenInclude(item => item.Creator)
            .Include(i => i.Creator)
            .Include(i => i.Accesses)
            .ThenInclude(access => access.User)
            .Include(i => i.Messages)
            .FirstOrDefaultAsync();
        return inventory;
    }

    private async Task<InventoryField> GetField(Guid fieldId)
    {
        InventoryField? field = await _dbContext.InventoryFields
            .Where(f => f.Id == fieldId)
            .Include(f => f.Inventory)
            .ThenInclude(i => i.Fields)
            .FirstOrDefaultAsync();
        return field ?? new InventoryField();
    }

    private async Task<Item?> GetItem(Guid itemId)
    {
        Item? item = await _dbContext.Items
            .Where(i => i.Id == itemId)
            .Include(i => i.Inventory)
            .ThenInclude(inventory => inventory.Fields)
            .Include(i => i.Creator)
            .Include(i => i.FieldValues)
            .ThenInclude(v => v.Field)
            .FirstOrDefaultAsync();
        return item;
    }

    public async Task<bool> RemoveItems(List<Guid> itemsIds, Guid contextId)
    {
        if (!itemsIds.Any())
            return false;
        List<Item> itemsToRemove = await _dbContext.Items
            .Where(i => itemsIds.Contains(i.Id))
            .ToListAsync();
        if (!itemsToRemove.Any())
            return false;
        _dbContext.Items.RemoveRange(itemsToRemove);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<Guid?> SaveItem(ItemViewModel itemViewModel, ApplicationUser user)
    {
        Item? item = await GetItem(itemViewModel.Id);
        if (item == null) item = await CreateNewItem(itemViewModel.InventoryId, user);
        if (item == null) return null;
        item.Edit(itemViewModel);
        if (!await CustomIdUniquenessCheck(item)) return null;
        await _dbContext.SaveChangesAsync();
        return item.Id;
    }

    private async Task<bool> CustomIdUniquenessCheck(Item item)
    {
        return !await _dbContext.Items
            .AnyAsync(i => i.InventoryId == item.InventoryId && i.CustomId == item.CustomId);
    }

    public async Task<HomePageViewModel?> GetHomePage(string userId)
    {
        ApplicationUser? user = await GetUser(userId);
        if (user == null) return null;
        HomePageViewModel viewModel = user.GetHomePage();
        List<Inventory> available = user.IsAdmin ? await GetAllInventories() : await GetPublicInventories();
        viewModel.AddToAvailableInventories(available.Select(i => i.ToViewModel()));
        return viewModel;
    }

    private async Task<ApplicationUser?> GetUser(string userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Where(u => string.Equals(u.Id, userId))
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

    private async Task<List<Inventory>> GetAllInventories()
    {
        return await _dbContext.Inventories
            .AsNoTracking() 
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .ToListAsync();
    }

    private async Task<List<Inventory>> GetPublicInventories()
    {
        return await _dbContext.Inventories
            .AsNoTracking() 
            .Where(i => i.IsPublic)
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .ToListAsync();
    }

    public async Task<bool> UserHasCreatorAccess(Guid inventoryId, ApplicationUser user)
    {
        Inventory? inventory = await GetInventoryBasic(inventoryId);
        if (inventory == null) return false;
        return user.IsAdmin || inventory.UserIsCreator(user);
    }

    public async Task<bool> UserHasWriteAccess(Guid inventoryId, ApplicationUser user)
    {
        Inventory? inventory = await GetInventoryBasic(inventoryId);
        if (inventory == null) return false;
        return user.IsAdmin || inventory.UserIsCreator(user) || inventory.UserHasWriteAccess(user);
    }

    private async Task<Inventory?> GetInventoryBasic(Guid inventoryId)
    {
        return await _dbContext.Inventories
            .AsNoTracking()
            .Where(i => i.Id == inventoryId)
            .Include(i => i.Accesses)
            .FirstOrDefaultAsync();
    }

    public async Task<Guid?> AddNewInventory(InventoryViewModel viewModel, ApplicationUser creator)
    {
        Inventory inventory = new(viewModel, creator);
        _dbContext.Inventories.Add(inventory);
        await _dbContext.SaveChangesAsync();
        return inventory.Id;
    }

    public async Task<int> DeleteUsers(List<string> ids)
    {
        return await _dbContext.Users
            .Where(u => ids.Contains(u.Id))
            .ExecuteDeleteAsync();
    }

    public async Task<int> BlockUsers(List<string> ids)
    {
        List<ApplicationUser> users = await _dbContext.Users
            .Where(u => ids.Contains(u.Id) && !u.IsBlocked)
            .ToListAsync();
        foreach (var user in users)
        {
            user.Block();
        }
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UnBlockUsers(List<string> ids)
    {
        List<ApplicationUser> users = await _dbContext.Users
            .Where(u => ids.Contains(u.Id) && u.IsBlocked)
            .ToListAsync();
        foreach (var user in users)
        {
            user.UnBlock();
        }
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> MakeUsersAdmin(List<string> ids)
    {
        List<ApplicationUser> users = await _dbContext.Users
            .Where(u => ids.Contains(u.Id) && !u.IsAdmin)
            .ToListAsync();
        foreach (var user in users)
        {
            user.MakeAdmin();
        }
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeAdminUsers(List<string> ids)
    {
        List<ApplicationUser> users = await _dbContext.Users
            .Where(u => ids.Contains(u.Id) && u.IsAdmin)
            .ToListAsync();
        foreach (var user in users)
        {
            user.DeAdmin();
        }
        return await _dbContext.SaveChangesAsync();
    }
    
    private async Task<List<Inventory>> GetLatestInventories(int max)
    {
        return await _dbContext.Inventories
            .AsNoTracking()
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .OrderByDescending(i => i.UpdatedAt)
            .Take(max)
            .ToListAsync();
    }
    
    private async Task<List<Inventory>> GetPopularInventories(int max)
    {
        return await _dbContext.Inventories
            .AsNoTracking()
            .Include(i => i.Creator)
            .Include(i => i.Items)
            .OrderByDescending(i => i.Items.Count())
            .Take(max)
            .ToListAsync();
    }

    public async Task AddNewMessage(ApplicationUser sender, Guid inventoryId, string text)
    {
        InventoryMessage message = new InventoryMessage(sender, inventoryId, text);
        await _dbContext.InventoryMessages.AddAsync(message);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> SetCustomIdSchema(Guid inventoryId, CustomIdSchema schema)
    {
        Inventory? inventory = await _dbContext.Inventories.FindAsync(inventoryId);
        if (inventory == null) return false;
        inventory.CustomIdSchemaJson = schema.ToJson();
        await _dbContext.SaveChangesAsync();
        return true;
    }
}