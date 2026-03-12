using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using ITask7.Models.Users;
using ITask7.Services.DbApi.Users;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;

namespace ITask7.Services.DbApi.Inventories;

public class InventoryService( IInventoryRepository inventoryRepo, IUserRepository userRepository) : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepo = inventoryRepo;
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<MainPageViewModel> GetMainPageAsync()
    {
        MainPageViewModel viewModel = new();
        viewModel.LatestInventories = (await _inventoryRepo.GetLatestAsync(viewModel.MaxLatestCount))
            .Select(i => i.ToViewModel()).ToList();
        viewModel.PopularInventories = (await _inventoryRepo.GetPopularAsync(viewModel.MaxPopularCount))
            .Select(i => i.ToViewModel()).ToList();
        return viewModel;
    }

    public async Task<InventoryViewModel?> GetByIdAsync(Guid id)
    {
        Inventory? inventory = await _inventoryRepo.GetDetailedAsync(id);
        return inventory?.ToViewModel();
    }

    public async Task<HomePageViewModel?> GetHomePageAsync(string userId)
    {
        ApplicationUser? user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return null;
        HomePageViewModel viewModel = user.GetHomePage();
        List<Inventory> available = user.IsAdmin ? await _inventoryRepo.GetAllAsync(): await _inventoryRepo.GetAllPublicAsync();
        viewModel.AddToAvailableInventories(available.Select(i => i.ToViewModel()));
        return viewModel;
    }

    public async Task<Guid?> CreateAsync(InventoryViewModel model, ApplicationUser creator)
    {
        return await _inventoryRepo.CreateAsync(model, creator);
    }

    public async Task<bool> UpdateAsync(InventoryViewModel model)
    {
        Inventory? inventory = await _inventoryRepo.GetByIdAsync(model.Id, true);
        if (inventory == null) return false;
        inventory.Edit(model);
        return await _inventoryRepo.UpdateAsync(inventory);
    }

    public async Task<bool> DeleteAsync(Guid inventoryId)
    {
        return await _inventoryRepo.DeleteAsync(inventoryId);
    }

    public async Task<bool> SetCustomIdSchemaAsync(Guid inventoryId, CustomIdSchema schema)
    {
        Inventory? inventory = await _inventoryRepo.GetByIdAsync(inventoryId, tracking: true);
        if (inventory == null) return false;
        inventory.CustomIdSchemaJson = schema.ToJson();
        inventory.RowVersion = schema.InventoryRowVersion;
        return await _inventoryRepo.UpdateAsync(inventory);
    }
}