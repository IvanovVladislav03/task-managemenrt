using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class User
    {
        public User(Guid id, string username, string passwordHash, string email)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            Role = UserRole.Developer;
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserRole Role { get; set; } 
    }

}
