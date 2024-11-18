using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class ProjectParticipant
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public UserRole RoleInProject { get; set; } // Пример перечисления для роли участника
        public DateTime JoinedAt { get; set; }
    }

}
