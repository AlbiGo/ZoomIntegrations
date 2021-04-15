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
using Zoom_Integration.Models.Entities;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.Utilites;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Services
{
    public class MeetingService : IMeetingService
    {
        public readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private IUserService _userService;

        public MeetingService(IConfiguration configuration, IMapper maper, IUserService userService)
        {
            _configuration = configuration;
            _mapper = maper;
            _userService = userService;
        }

        public async Task<MeetingViewModel> createMeeting(string apiToken, CreateMeetingDTO meetingRequest)
        {
            try
            {
                var createdMeetingDTO = new CreatedMeetingDTO();
                var meetingViewModel = new MeetingViewModel();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:3:url").Value;
                var currentUserID = await _userService.getcurrentUserDetails(apiToken);
                url = url.Replace("userId", currentUserID.id);//String Format can be used here
                var payload = JsonConvert.SerializeObject(meetingRequest);
                using (var httpClient = new HttpClient())
                {
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.PostAsync(url, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<CreatedMeetingDTO>(apiResponse);
                        createdMeetingDTO = res;
                        meetingViewModel = _mapper.Map<MeetingViewModel>(createdMeetingDTO);

                    }
                    else
                        throw new Exception(response.StatusCode.ToString());

                }
                return meetingViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task deleteMeeting(string apiToken, string id)
        {
            try
            {
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:5:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var queryString = new QueryString(string.Empty).ToString();
                    queryString = id;
                    url = url + "/?" + queryString;
                    var response = await httpClient.DeleteAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }
                    else
                        throw new Exception(response.StatusCode.ToString());



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task updateMeeting(string apiToken, UpdateMeetingDTO meetingRequest, string id)
        {
            try
            {
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:6:url").Value;
                using (var httpClient = new HttpClient())
                {
                    var payload = JsonConvert.SerializeObject(meetingRequest);
                    HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var queryString = new QueryString(string.Empty).ToString();
                    queryString = id;
                    url = url + "/" + queryString;
                    var response = await httpClient.PutAsync(url, content);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new Exception("You dont have sufficent permisions");

                    }
                    else
                        throw new Exception(response.StatusCode.ToString());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MeetingViewModel> getMeeting(string apiToken, string id)
        {
            try
            {
                var meetingViewModel = new MeetingViewModel();
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:7:url").Value;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var queryString = new QueryString(string.Empty).ToString();
                    queryString = id;
                    url = url + "/" + queryString;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = JsonConvert.DeserializeObject<Meeting>(apiResponse);
                        var user = await this._userService.getUser(apiToken, res.host_id);
                        meetingViewModel = _mapper.Map<MeetingViewModel>(res);
                        meetingViewModel.hostEmail = user.email;
                        meetingViewModel.contact_email = user.email;
                        meetingViewModel.contact_name = user.first_name + user.last_name;

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }

                }
                return meetingViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MeetingrPageInfoDTO> getAll(string apiToken,MeetingFilter filter)
        {
            try
            {
                var meetingViewModel = new MeetingrPageInfoDTO();
                //Build query string
                var query = Utilities.buildQueryString(filter);
                var url = _configuration.GetSection("ZoomEndpoints:Endpoints:3:url").Value;
                url = url + "?" + query;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                    var currentUserID = await _userService.getcurrentUserDetails(apiToken);
                    url = url.Replace("userId", currentUserID.id);//String Format can be used here
                    var response = await httpClient.GetAsync(url);
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        meetingViewModel = JsonConvert.DeserializeObject<MeetingrPageInfoDTO>(apiResponse);

                    }
                    else
                    {
                        var resError = JsonConvert.DeserializeObject<ApiResponseDTO>(apiResponse);
                        throw new Exception(resError.message.ToString());
                    }

                }
                return meetingViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
