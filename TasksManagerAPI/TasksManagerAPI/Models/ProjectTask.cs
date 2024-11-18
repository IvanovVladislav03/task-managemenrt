using TasksManagerAPI.Models.Enums;

namespace TasksManagerAPI.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; } // Пример перечисления для статуса
        public TaskPriority Priority { get; set; } // Пример перечисления для приоритета
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int CreatedBy { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
