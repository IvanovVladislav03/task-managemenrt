using System.Text.Json.Serialization;

namespace TasksManagerAPI.Models
{
    public class TaskAssignee
    {
        public TaskAssignee(Guid taskId, Guid userId)
        {
            Id = Guid.NewGuid();
            TaskId = taskId;
            UserId = userId;
        }
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        [JsonIgnore]
        public ProjectTask? Task { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }

}
