using System.ComponentModel.DataAnnotations;

namespace TasksManagerAPI.Models
{
    public class Project
    {
        public Project(string title, string description, Guid createdById)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreatedById = createdById;
            CreatedAt = DateTime.Now;
            ProjectParticipants = new List<ProjectParticipant>();
        }

        public Guid Id { get; set; }
        public  string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedById { get; set; }
        public User? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ProjectParticipant> ProjectParticipants { get; set; }
    }

}
