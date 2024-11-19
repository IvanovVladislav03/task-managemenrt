using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class ProjectParticipant
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public UserRole RoleInProject { get; set; } // Пример перечисления для роли участника
        public DateTime JoinedAt { get; set; }
    }

}
