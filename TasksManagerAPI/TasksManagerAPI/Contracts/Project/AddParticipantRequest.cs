using TaskManagementAPI.Models.Enums;

namespace TaskManagementAPI.Contracts.Project
{
    public class AddParticipantRequest
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
    }
}
