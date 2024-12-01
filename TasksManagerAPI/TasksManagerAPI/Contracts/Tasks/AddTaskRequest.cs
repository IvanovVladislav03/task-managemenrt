using TasksManagerAPI.Models.Enums;

namespace TaskManagementAPI.Contracts.Tasks
{
    public class AddTaskRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TasksManagerAPI.Models.Enums.TaskStatus Status { get; set; } // Пример перечисления для статуса
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }

    }
}
