using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TaskManagementAPI.Interfaces;
using TasksManagerAPI.Data;
using TasksManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAPI.Repositories
{
    public class UsersRepository:IUsersRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var userEntity =  await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);  
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            //await _context.Users.UpdateAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null) 
                _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
