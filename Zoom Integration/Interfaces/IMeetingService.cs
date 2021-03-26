using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Interfaces
{
    public interface IMeetingService
    {
        public Task<MeetingViewModel> createMeeting(string apiToken, CreateMeetingDTO meetingRequest);

    }
}
