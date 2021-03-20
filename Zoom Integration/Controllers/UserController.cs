using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;

namespace Zoom_Integration.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

      //  [Authorize]
        [HttpGet("~/api/v1/getCurrentUser")]
        public async Task<IActionResult> getCurrentUser()
        {
            try
            {
                var isAuth = HttpContext.Request.Headers.ContainsKey("Authorization");
                if(!isAuth)
                {
                    return Unauthorized("You dont have a valid api key");
                }
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Replace("Bearer ", "");
                var user =await _userService.getUserInformation(apiNew);
                if (user.id == null)
                {
                    return new NotFoundResult();
                }
                else return Ok(user);

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

    }
}
