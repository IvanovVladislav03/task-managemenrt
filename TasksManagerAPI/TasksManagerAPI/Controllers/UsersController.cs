using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Interfaces;
using TasksManagerAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                await _userRepository.AddUserAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
