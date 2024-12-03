using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class ProjectTask
    {
        public ProjectTask(Guid projectId, Guid createdById, string title, string description, Enums.TaskStatus status, TaskPriority priority, DateTime dueDate)
        {
            Id = Guid.NewGuid();
            ProjectId = projectId;
            CreatedById = createdById;
            Title = title;
            Description = description;
            Status = status;
            Priority = priority;
            DueDate = dueDate;
            CreatedAt = DateTime.UtcNow;

            TaskAssignees = new List<TaskAssignee>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Enums.TaskStatus Status { get; set; } // Пример перечисления для статуса
        public TaskPriority Priority { get; set; } // Пример перечисления для приоритета
        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public Guid CreatedById { get; set; }
        public User? CreatedByUser { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TaskAssignee> TaskAssignees { get; set; }
    }

}
