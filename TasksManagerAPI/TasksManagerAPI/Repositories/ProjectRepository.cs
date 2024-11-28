using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TasksManagerAPI.Data;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Repositories
{
    public class ProjectRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProjectRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddProject(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }
        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception("Project has not found");

            return project;
        }

        public async Task<IEnumerable<Project>> GetAllUserProjects(Guid userId)
        {
            var projects = _context.Projects
                .Where(p => p.ProjectParticipants.Any(pp => pp.UserId == userId)) ;

            return await projects.ToListAsync();
        }

        public async Task AddParticipant(ProjectParticipant projectParticipant)
        {
            var project = await GetProjectByIdAsync(projectParticipant.ProjectId);
            project.ProjectParticipants.Add(projectParticipant);
            await _context.SaveChangesAsync();
        }
    }
}
