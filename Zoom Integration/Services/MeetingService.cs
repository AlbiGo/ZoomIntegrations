using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zoom_Integration.Interfaces;
using Zoom_Integration.Models.ConfigDTO;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Services
{
	public class MeetingService : IMeetingService
	{
        public readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private IUserService _userService;

        public MeetingService(IConfiguration configuration, IMapper maper , IUserService userService)
        {
            _configuration = configuration;
            _mapper = maper;
            _userService = userService;
        }

        public async Task<MeetingViewModel> createMeeting(string apiToken , CreateMeetingDTO meetingRequest)
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
                    var response = await httpClient.PostAsync(url , content);
                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<CreatedMeetingDTO>(apiResponse);
                        createdMeetingDTO = res;
                        meetingViewModel = _mapper.Map<MeetingViewModel>(createdMeetingDTO);

                    }
                    else
                        throw new Exception("Unauthorized");

                }
                return meetingViewModel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
