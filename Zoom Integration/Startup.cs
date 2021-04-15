using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;
using Zoom_Integration.Middleware;
using Zoom_Integration.Models.ConfigDTO;
using Zoom_Integration.Repository;
using Zoom_Integration.Services;

namespace Zoom_Integration
{
    public class Startup
    {
        

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var identitySettingsSection = Configuration.GetSection("ZoomEndpoints:EndPoints");
            services.Configure<List<EndPoints>>(identitySettingsSection);
            //Dependency Injection
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            //Automapper
            services.AddAutoMapper(typeof(Startup));
            var secretKey = Configuration["AppSettings:Secret"];

            services.AddAuthentication(opt =>
            { //JWT Auth
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourAppServer",
                    ValidAudience = "yourAppServer",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<Auth>();
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
