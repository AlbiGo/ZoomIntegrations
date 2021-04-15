using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Zoom_Integration.Interfaces;
using Zoom_Integration.Models.ConfigDTO;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Services
{
    public class UserService : IUserService
    {
        public readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration , IMapper maper)
        {
            _configuration = configuration;
            _mapper = maper;
        }
        public async Task<UserPageInfoDTO> getAllUsers(string apiToken , UserFilter filter)
        {
            try
            {
                var users = new UserPageInfoDTO();
                var query = Utilites.Utilities.buildQueryString(filter);
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:0:url").Value;
                url = url + "?" + query;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<UserPageInfoDTO>(apiResponse);
                        users = res;
                    }
                    else
                        throw new Exception(response.StatusCode.ToString());

                }
                return users;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserViewModel> getcurrentUser(string apiToken)
        {
            try
            {
                var user = new UserInformationDTO();
                var userView = new UserViewModel();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:2:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = JsonConvert.DeserializeObject<UserInformationDTO>(apiResponse);
                        user = res;
                        userView = _mapper.Map<UserViewModel>(user);

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }
                        

                }
                return userView;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserInformationDTO> getUser(string apiToken ,string userId)
        {
            try
            {
                var user = new UserInformationDTO();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:0:url").Value;
                var queryString = new QueryString(string.Empty).ToString();
                queryString = userId;
                url = url + "/" + queryString;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = JsonConvert.DeserializeObject<UserInformationDTO>(apiResponse);
                        user = res;

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }

                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<UserInformationDTO> getcurrentUserDetails(string apiToken)
        {
            try
            {
                var user = new UserInformationDTO();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:2:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = JsonConvert.DeserializeObject<UserInformationDTO>(apiResponse);
                        user = res;

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }

                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CreatedUserDTO> createUser(string apiToken , CreateUserDTO model)
        {
            try
            {
                var userCurrent = await this.getcurrentUserDetails(apiToken);
                var user = new CreatedUserDTO();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:4:url").Value;
                using (var httpClient = new HttpClient())
                {
                    var payload = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.PostAsync(url , content);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = JsonConvert.DeserializeObject<CreatedUserDTO>(apiResponse);
                        user = res;

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }

                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task deleteUser(string apiToken,  string userID)
        {
            try
            {
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:4:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var queryString = new QueryString(string.Empty).ToString();
                    queryString = userID;
                    url = url + "/" + queryString;
                    var response = await httpClient.DeleteAsync(url);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }
                    
                   
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task updateUser(string apiToken, updateUserDTO model ,string userId)
        {
            try
            {
                var userCurrent = await this.getcurrentUserDetails(apiToken);
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:4:url").Value;
                using (var httpClient = new HttpClient())
                {
                    var payload = JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var queryString = new QueryString(string.Empty).ToString();
                    queryString = userId;
                    url = url + "/" + queryString;
                    var response = await httpClient.PutAsync(url, content);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());

                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
