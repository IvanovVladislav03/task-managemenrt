using TasksManagerAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface ITasksRepository
    {
        Task AddTaskAsync(ProjectTask task);
        Task DeleteTask(Guid id);
        Task<IEnumerable<ProjectTask>> GetProjectTasksAsync(Guid projectId);
        Task <ProjectTask> GetTaskByIdAsync(Guid id);
        Task UpdateTask(ProjectTask task);
        Task AddAssignee(TaskAssignee taskAssignee);
    }
}