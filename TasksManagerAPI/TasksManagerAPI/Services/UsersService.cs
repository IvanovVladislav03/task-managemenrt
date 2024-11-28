using Microsoft.AspNetCore.Identity;
using TaskManagementAPI.Interfaces;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;
        public UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
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

            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
    }
}
