using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;

namespace ITask7.Services.DbApi.Inventories;

public class InventoryService( IInventoryRepository inventoryRepo) : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    
    public Task<MainPageViewModel> GetMainPageAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<InventoryViewModel?> GetByIdAsync(Guid id)
    {
        Inventory? inventory = await _inventoryRepo.GetDetailedAsync(id);
        return inventory?.ToViewModel();
    }

    public Task<HomePageViewModel?> GetHomePageAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Guid?> CreateAsync(InventoryViewModel model, ApplicationUser creator)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(InventoryViewModel model)
    {
        Inventory? inventory = await _inventoryRepo.GetByIdAsync(model.Id, true);
        if (inventory == null) return false;
        inventory.Edit(model);
        return await _inventoryRepo.UpdateAsync(inventory);
    }

    public Task<bool> SetCustomIdSchemaAsync(Guid inventoryId, CustomIdSchema schema)
    {
        throw new NotImplementedException();
    }
}