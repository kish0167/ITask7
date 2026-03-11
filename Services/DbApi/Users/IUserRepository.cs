using ITask7.Models.Users;

namespace ITask7.Services.DbApi.Users;

public interface IUserRepository
{
    Task<ApplicationUser?> GetByIdAsync(string id);
    Task<ApplicationUser?> GetByUsernameAsync(string username);
    Task<List<ApplicationUser>> GetAllAsync();
    Task<int> DeleteAsync(List<string> ids);
    Task<int> BlockAsync(List<string> ids);
    Task<int> UnblockAsync(List<string> ids);
    Task<int> MakeAdminAsync(List<string> ids);
    Task<int> RemoveAdminAsync(List<string> ids);
}