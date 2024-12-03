using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementAPI.Contracts.Tasks;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Repositories;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/projects/{projectId:Guid}/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository _taskRepository;
        public TasksController(ITasksRepository tasksRepository)
        {
            _taskRepository = tasksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks([FromRoute] Guid projectId)
        {
            var tasks = await _taskRepository.GetProjectTasksAsync(projectId);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] AddTaskRequest request, [FromRoute] Guid projectId)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                throw new UnauthorizedAccessException("User is not authenticated or has invalid identifier.");

            var task = new ProjectTask(projectId, new Guid(userId), request.Title, request.Description, request.Status,
                request.Priority, request.DueDate);
            await _taskRepository.AddTaskAsync(task);

            return Ok(task);

        }

        [HttpPost("add-assignee")]
        public async Task<IActionResult> AddTaskAssignee([FromBody] AddAssigneeRequest request)
        {
            var taskAssignee = new TaskAssignee(request.TaskId, request.UserId);
            await _taskRepository.AddAssignee(taskAssignee);
            return Ok(taskAssignee);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask([FromBody] Guid taskId)
        {
            await _taskRepository.DeleteTask(taskId);
            return Ok();
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequest request, [FromRoute] Guid projectId)
        //{
        //    var task = _taskRepository.GetTaskByIdAsync(request.Id);
        //}
    }
}
