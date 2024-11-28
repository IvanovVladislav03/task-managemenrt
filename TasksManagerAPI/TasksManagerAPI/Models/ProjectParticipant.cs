using TaskManagementAPI.Models.Enums;
using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class ProjectParticipant
    {
        public ProjectParticipant(Guid projectId, Guid userId, ProjectRole roleInProject)
        {
            Id = Guid.NewGuid();
            ProjectId = projectId;
            UserId = userId;
            RoleInProject = roleInProject;
            JoinedAt = DateTime.UtcNow;      
        }
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public ProjectRole RoleInProject { get; set; } // Пример перечисления для роли участника
        public DateTime JoinedAt { get; set; }
    }

}
