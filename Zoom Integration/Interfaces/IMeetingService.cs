using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Interfaces
{
    public interface IMeetingService
    {
        public Task<MeetingViewModel> createMeeting(string apiToken, CreateMeetingDTO meetingRequest);
        public Task deleteMeeting(string apiToken, string id);
        public Task updateMeeting(string apiToken, UpdateMeetingDTO meetingRequest ,string id);
        public Task<MeetingViewModel> getMeeting(string apiToken, string id);
        public Task<MeetingrPageInfoDTO> getAll(string apiToken,MeetingFilter filter);



    }
}
