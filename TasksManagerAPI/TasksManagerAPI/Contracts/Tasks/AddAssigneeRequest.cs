namespace TaskManagementAPI.Contracts.Tasks
{
    public class AddAssigneeRequest
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }

    }
}
