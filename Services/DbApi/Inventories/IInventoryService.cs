using ITask7.Models.CustomId;
using ITask7.Models.Users;
using ITask7.ViewModels.Inventories;
using ITask7.ViewModels.Pages;

namespace ITask7.Services.DbApi.Inventories;

public interface IInventoryService
{
    Task<MainPageViewModel> GetMainPageAsync();
    Task<InventoryViewModel?> GetByIdAsync(Guid id);
    Task<HomePageViewModel?> GetHomePageAsync(string userId);
    Task<Guid?> CreateAsync(InventoryViewModel model, ApplicationUser creator);
    Task<bool> UpdateAsync(InventoryViewModel model);
    Task<bool> SetCustomIdSchemaAsync(Guid inventoryId, CustomIdSchema schema);
}