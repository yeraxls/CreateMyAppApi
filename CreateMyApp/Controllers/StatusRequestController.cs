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
    //[Authorize]
    public class StatusRequestController : ControllerBase
    {
        private readonly ILogger<StatusRequestController> _logger;
        private readonly IStatusRequestService _statusRequestService;

        public StatusRequestController(ILogger<StatusRequestController> logger, IStatusRequestService statusRequestService)
        {
            _logger = logger;
            _statusRequestService = statusRequestService;
        }

        [HttpGet(Name = "Get Requests")]
        public async Task<ActionResult> GetRequests([FromBody] NewUser newUser)
        {
            try
            {
                return Ok(await _statusRequestService.GetStatusRequests());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("new-request")]
        public async Task<ActionResult> NewRequest([FromBody] NewStatusRequest newStatus)
        {
            try
            {
                await _statusRequestService.NewStatusRequest(newStatus);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update-request")]
        public async Task<ActionResult> UpdateRequest([FromBody] UpdateStatusRequestDTO statusRequest)
        {
            try
            {
                await _statusRequestService.UpdateStatusRequest(statusRequest);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
