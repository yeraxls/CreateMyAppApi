using CreateMyApp.Models.User;
using CreateMyApp.Services;
using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreateMyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] NewUser newUser)
        {
            try
            {
                await _userService.Register(newUser);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost(Name = "login")]
        public async Task<ActionResult> Login(LoginModel login)
        {
            try
            {
                var user = await _userService.Authenticate(login);
                if (user == null)
                    return NotFound("Usuario no encontrado");
                if (user.LeavingDate != null)
                    return Unauthorized("This user is desactivate");
                var token = _userService.Generate(user);
                return Ok(token);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("update-user")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserDTO userDTO)
        {
            try
            {
                var user = await _userService.SearchUser(userDTO);
                if (user != null)
                {
                    await _userService.UpdateUser(userDTO, user);
                    return Ok();
                }
                return NotFound("Usuario no encontrado");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
