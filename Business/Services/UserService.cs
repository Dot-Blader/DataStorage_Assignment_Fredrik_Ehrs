using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class UserService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    public async Task CreateUserAsync(UserRegistrationForm form)
    {
        await _userRepository.BeginTransactionAsync();

        try
        {
            var userEntity = UserFactory.Create(form);
            await _userRepository.AddAsync(userEntity!);

            await _userRepository.SaveAsync();
            await _userRepository.CommitTransactionAsync();
        }
        catch
        {
            await _userRepository.RollbackTransactionAsync();
        }
    }
    public async Task<IEnumerable<User?>> GetUsersAsync()
    {
        var userEntities = await _userRepository.GetAsync();
        return userEntities.Select(UserFactory.Create)!;
    }
    public async Task<User?> GetUserByIdAsync(string id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        return UserFactory.Create(userEntity!);
    }
    public async Task<User?> GetUserByNameAsync(string firstName, string lastName)
    {
        var userEntity = await _userRepository.GetAsync(x => x.FirstName == firstName && x.LastName == lastName);
        return UserFactory.Create(userEntity!);
    }
    public async Task<bool> UpdateUserAsync(User user)
    {
        try
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == user.Id);
            userEntity!.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            _userRepository.Update(userEntity!);
            return true;
        }
        catch { return false; }
    }
    public async Task<bool> DeleteUserAsync(string id)
    {
        try
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == id);
            _userRepository.Delete(userEntity!);
            return true;
        }
        catch { return false; }
    }
}
