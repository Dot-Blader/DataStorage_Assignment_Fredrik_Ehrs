using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class UserService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    public async Task CreateUserAsync(UserRegistrationForm form)
    {
        var userEntity = UserFactory.Create(form);
        await _userRepository.AddAsync(userEntity!);
    }
    public async Task<IEnumerable<User?>> GetUsersAsync()
    {
        var userEntities = await _userRepository.GetAsync();
        return userEntities.Select(UserFactory.Create)!;
    }
    public async Task<User?> GetUserByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        return UserFactory.Create(userEntity!);
    }
    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == user.Id);
            await _userRepository.UpdateAsync(userEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteUserAsync(int id)
    {
        try
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == id);
            await _userRepository.DeleteAsync(userEntity!);
            return true;
        }
        catch { return false; }
    }
}
