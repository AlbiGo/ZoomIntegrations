using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;
using Zoom_Integration.Models.ConfigDTO;
using Zoom_Integration.Models.ResponseDTO;

namespace Zoom_Integration.Services
{
    public class UserService : IUserService
    {
        public readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<User>> getAllUsers(string apiToken)
        {
            try
            {
                var users = new List<User>();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:0:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<PageInfoDTO>(apiResponse);
                        users = res.users;
                    }
                   
                }
                return users;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
