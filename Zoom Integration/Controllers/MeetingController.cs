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

    /// <summary>  
    /// The class that handles all requests to Meeting Entity
    /// </summary>  
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IMeetingService _meetingService;
        /// <summary>  
        /// Constructor
        /// </summary>  
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;

        }
        /// <summary>  
        /// Create Meeting
        /// </summary>  
        /// <param name="model"> Meeting Object </param>  
        /// <returns>Returns HTTP Response</returns>   
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
                var apiNew = apiKey.Split(" ")[1];
                var result = await this._meetingService.createMeeting(apiNew, model);
                return new OkObjectResult(result);
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }


        /// <summary>  
        /// Update Meeting
        /// </summary>  
        /// <param name="model"> Meeting Object </param>  
        /// <param name="meetingId"> Meeting ID</param>  
        /// <returns>Returns HTTP Response</returns>   
        [HttpPost("~/api/v1/updateMeeting")]
        public async Task<IActionResult> updateMeeting([FromBody] UpdateMeetingDTO model, string meetingId)
        {
            try
            {
                var isAuth = HttpContext.Request.Headers.ContainsKey("Authorization");
                if (!isAuth)
                {
                    return Unauthorized("You dont have a valid api key");
                }
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                await this._meetingService.updateMeeting(apiNew, model, meetingId);
                return new OkResult();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Delete Meeting
        /// </summary>  
        /// <param name="meetingId"> Meeting ID</param>  
        /// <returns>HTTP Response</returns>   
        [HttpDelete("~/api/v1/deleteMeeting")]
        public async Task<IActionResult> deleteMeeting( string meetingId)
        {
            try
            {
               
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                await this._meetingService.deleteMeeting(apiNew, meetingId);
                return new OkResult();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Get Meeting by ID
        /// </summary>  
        /// <param name="meetingId"> Meeting ID</param>  
        /// <returns>Meeting</returns>   
        [HttpGet("~/api/v1/getMeeting")]
        public async Task<IActionResult> getMeeting([FromQuery] string meetingId)
        {
            try
            {
                
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var result = await this._meetingService.getMeeting(apiNew, meetingId);
                return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Get all Meetings  
        /// </summary>  
        /// <returns>Returns a paginated list of Meetings</returns>  
        [HttpGet("~/api/v1/gellAllMeetings")]
        public async Task<IActionResult> gellAllMeetings([FromQuery] MeetingFilter filter)
        {
            try
            {

                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var result = await this._meetingService.getAll(apiNew,filter);
                return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

    }
}
