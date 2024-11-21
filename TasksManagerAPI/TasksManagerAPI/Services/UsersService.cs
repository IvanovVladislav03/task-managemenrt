using Microsoft.AspNetCore.Identity;
using TaskManagementAPI.Interfaces;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task Register(string userName, string email, string password)
        {
            var passwordHash = _passwordHasher.Generate(password);

            var user = new User(new Guid(), userName, passwordHash, email);

            await _usersRepository.AddUserAsync(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);
            if (!_passwordHasher.Verify(password, user.PasswordHash))
            {
                throw new Exception("Failed to login");
            }

            return "";
        }
    }
}
