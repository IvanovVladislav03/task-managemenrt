using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Contracts.Users;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersService _userService;
        public AuthController(UsersService usersService)
        {
            _userService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);

            return Ok();
        }

        //[HttpPost("login")]
        //public  async Task<IResult> Login([FromBody] LoginUserRequest request)
        //{
        //    var token = await _userService.Login(request.Email, request.Password);
        //    return "";
        //}
    }
}
