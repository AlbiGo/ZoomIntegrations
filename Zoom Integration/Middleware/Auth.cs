using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zoom_Integration.Utilites;

namespace Zoom_Integration.Middleware
{
    public class Auth
    {
        private readonly RequestDelegate _next;
        public Auth(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];

            //do the checking
            if (token == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Access denied! You dont have an authorization token.");
                return;
            }
            else if(!token.Contains("bearer", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Access denied! The format of your token is not valid.");
                return;
            }
            else
            {
                token = token.Substring("bearer ".Length).Trim();
                if (Utilities.IsBase64String(token))
                {
                    await context.Response.WriteAsync("Access denied! The format of your token is not valid.");

                }
            }

            //pass request further if correct
            await _next(context);
        }
       
    }
}
