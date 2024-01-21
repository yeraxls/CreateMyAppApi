using CreateMyApp.Models;
using CreateMyApp.Services;
using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreateMyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TaskRequestController : ControllerBase
    {
        private readonly ILogger<TaskRequestController> _logger;
        private readonly IUserService _userService;

        public TaskRequestController(ILogger<TaskRequestController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "Get Requests")]
        public async Task<ActionResult> GetRequests([FromBody] NewUser newUser)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("new-request")]
        public async Task<ActionResult> NewRequest([FromBody] NewUser newUser)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update-request")]
        public async Task<ActionResult> NewRequest()
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update-request")]
        public async Task<ActionResult> UpdateRequest(UpdateStatusRequestDTO statusRequest)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
