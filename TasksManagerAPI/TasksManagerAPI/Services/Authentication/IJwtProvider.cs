using TasksManagerAPI.Models;

namespace TaskManagementAPI.Services.Authentication
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}