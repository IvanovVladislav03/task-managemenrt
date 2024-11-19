namespace TasksManagerAPI.Models
{
    public class Project
    {
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ProjectParticipant> ProjectParticipants { get; set; }
    }

}
