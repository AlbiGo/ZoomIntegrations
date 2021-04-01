using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                await context.Response.WriteAsync("Access denied!");
                return;
            }

            //pass request further if correct
            await _next(context);
        }
    }
}
