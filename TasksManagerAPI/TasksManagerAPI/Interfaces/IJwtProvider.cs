using TasksManagerAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}