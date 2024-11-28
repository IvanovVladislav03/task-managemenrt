using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using TaskManagementAPI.Contracts.Project;
using TaskManagementAPI.Repositories;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController:ControllerBase
    {
        private readonly ProjectRepository _projectRepository;
        public ProjectController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProjects()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? 
                throw new UnauthorizedAccessException("User is not authenticated or has invalid identifier.");
            
            var projects = await _projectRepository.GetAllUserProjects(new Guid(userId));
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] CreateProjectRequest request)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                 throw new UnauthorizedAccessException("User is not authenticated or has invalid identifier.");

            var project = new Project(request.Title, request.Description, new Guid(userId));
            await _projectRepository.AddProject(project);
            return Ok(project);
        }

        [HttpPost("add-participant")]
        public async Task<IActionResult> AddParticipant([FromBody] AddParticipantRequest request)
        {
            var participant = new ProjectParticipant(request.ProjectId, request.UserId, request.Role);
            await _projectRepository.AddParticipant(participant);
            return Ok(participant);
        }
    }
}
