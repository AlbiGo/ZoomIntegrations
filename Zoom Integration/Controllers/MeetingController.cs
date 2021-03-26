using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;
using Zoom_Integration.Models.RequestDTO;

namespace Zoom_Integration.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpPost("~/api/v1/createMeeting")]
        public async Task<IActionResult> createMeeting([FromBody] CreateMeetingDTO model )
        {
            try
            {
                var isAuth = HttpContext.Request.Headers.ContainsKey("Authorization");
                if (!isAuth)
                {
                    return Unauthorized("You dont have a valid api key");
                }
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Replace("Bearer ", "");
                var result = await this._meetingService.createMeeting(apiNew, model);
                return new OkObjectResult(result);
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
    }
}
