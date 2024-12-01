using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Interfaces;
using TasksManagerAPI.Data;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TasksRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddTaskAsync(ProjectTask task)
        {
            await _context.ProjectTasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectTask>> GetProjectTasksAsync(Guid projectId)
        {
            var tasks = _context.ProjectTasks.Where(task => task.ProjectId == projectId);
            return await tasks.ToListAsync();
        }

        public async Task UpdateTask(ProjectTask task)
        {
            var existingTask = await _context.ProjectTasks.FirstOrDefaultAsync(t => t.Id == task.Id) ?? throw new Exception();
            _context.Entry(existingTask).CurrentValues.SetValues(task);
        }

        public async Task DeleteTask(Guid id)
        {
            var task = await _context.ProjectTasks.FirstOrDefaultAsync(task => task.Id == id) ?? throw new Exception();
            _context.ProjectTasks.Remove(task);
        }
    }
}
