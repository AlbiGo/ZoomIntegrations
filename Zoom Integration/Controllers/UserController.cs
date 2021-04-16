using Microsoft.AspNetCore.Authorization;  
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
    /// The class that handles all requests to User Entity
    /// </summary>  
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>  
        /// Constructor
        /// </summary>  
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        /// <summary>  
        /// Get all Users  
        /// </summary>  
        /// <returns>Returns a paginated list of Users</returns>  
        [HttpGet("~/api/v1/getAllUsers")]
        public async Task<IActionResult> getAllUsers([FromQuery] UserFilter filter)
        {
            try
            {
               
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var users =   await _userService.getAllUsers(apiNew, filter);
                return Ok(users);

            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }



        /// <summary>  
        /// Get the current logged User  
        /// </summary>  
        /// <returns>Returns the correct logged User</returns>   
        [HttpGet("~/api/v1/getCurrentUser")]
        public async Task<IActionResult> getCurrentUser()
        {
            try
            {
                var t = HttpContext.Request.Headers.Where(p => p.Key == "Authorization").FirstOrDefault().Value;
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var user = await _userService.getcurrentUser(apiNew);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

        /// <summary>  
        /// Get the current logged User  details
        /// </summary>  
        /// <returns>Returns the correct logged User details</returns>   
        [HttpGet("~/api/v1/getcurrentUserDetails")]
        public async Task<IActionResult> getcurrentUserDetails()
        {
            try
            {
               
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var user = await _userService.getcurrentUserDetails(apiNew);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Get  User  details
        /// </summary>  
        /// <param name="userId"> User ID</param>  
        /// <returns>Returns the correct logged User details</returns>   
        [HttpGet("~/api/v1/getUserInfo")]
        public async Task<IActionResult> getUserInfo(string userId)
        {
            try
            {

                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                var user = await _userService.getUser(apiNew, userId);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

        /// <summary>  
        /// Create User
        /// </summary>  
        /// <param name="model"> User Object </param>  
        /// <returns>Returns HTTP Response</returns>   
        [HttpPost("~/api/v1/createUser")]
        public async Task<IActionResult> createUser([FromBody] CreateUserDTO model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new BadRequestResult();
                }
                
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                await _userService.createUser(apiNew , model);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Update User
        /// </summary>  
        /// <param name="model"> User Object </param>  
        /// <param name="userId"> User ID</param>  
        /// <returns>Returns HTTP Response</returns>   
        [HttpPut("~/api/v1/updateUser")]
        public async Task<IActionResult> updateUser([FromBody] UpdateUserDTO model,[FromQuery] string userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new BadRequestResult();
                }

                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                await _userService.updateUser(apiNew, model, userId);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }
        /// <summary>  
        /// Delete User
        /// </summary>  
        /// <param name="userId"> User ID</param>  
        /// <returns>HTTP Response</returns>   
        [HttpDelete("~/api/v1/deleteUser")]
        public async Task<IActionResult> deleteUser( [FromQuery] string userId)
        {
            try
            {
                var t = HttpContext.Request.Headers.Where(p => p.Key == "Authorization").FirstOrDefault().Value;
                var apiKey = HttpContext.Request.Headers["Authorization"].FirstOrDefault().ToString();
                var apiNew = apiKey.Split(" ")[1];
                await _userService.deleteUser(apiNew, userId);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");

            }
        }

    }
}
