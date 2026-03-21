using ITask7.ViewModels;

namespace ITask7.Services.DbApi.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<UserViewModel>> GetAllAsync()
    {
        return (await _userRepository.GetAllAsync()).Select(u => u.ToViewModel()).ToList();
    }

    public async Task<int> Delete(List<string> userIds)
    {
        return await _userRepository.DeleteAsync(userIds);
    }

    public async Task<int> BlockAsync(List<string> userIds)
    {
        return await _userRepository.BlockAsync(userIds);
    }

    public async Task<int> UnblockAsync(List<string> ids)
    {
        return await _userRepository.UnblockAsync(ids);
    }

    public async Task<int> MakeAdminAsync(List<string> ids)
    {
        return await _userRepository.MakeAdminAsync(ids);
    }

    public async Task<int> RemoveAdminAsync(List<string> ids)
    {
        return await _userRepository.RemoveAdminAsync(ids);
    }

    public async Task<bool> SetSalesForceId(string userId, string salesForceId)
    {
        return await _userRepository.SetSalesForceId(userId, salesForceId);
    }

    public async Task<bool> RemoveSalesForceId(string userId)
    {
        return await _userRepository.SetSalesForceId(userId, null);
    }
}