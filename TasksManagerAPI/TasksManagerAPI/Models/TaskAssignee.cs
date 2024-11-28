namespace TasksManagerAPI.Models
{
    public class TaskAssignee
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public ProjectTask? Task { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }

}
