using TasksManagerAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();

    }
}
