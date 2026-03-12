using ITask7.ViewModels;

namespace ITask7.Services.DbApi.Users;

public interface IUserService
{
    Task<List<UserViewModel>> GetAllAsync();
    Task<int> Delete(List<string> userIds);
    Task<int> BlockAsync(List<string> userIds);
    Task<int> UnblockAsync(List<string> ids);
    Task<int> MakeAdminAsync(List<string> ids);
    Task<int> RemoveAdminAsync(List<string> ids);
}