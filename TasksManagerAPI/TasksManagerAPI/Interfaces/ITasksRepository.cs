﻿using TasksManagerAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface ITasksRepository
    {
        Task AddTaskAsync(ProjectTask task);
        Task DeleteTask(Guid id);
        Task<IEnumerable<ProjectTask>> GetProjectTasksAsync(Guid projectId);
        Task UpdateTask(ProjectTask task);
    }
}