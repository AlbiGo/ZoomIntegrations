using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.Entities;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Models.ResponseDTO
{
    public class MeetingrPageInfoDTO
    {
        public int page_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
        public int total_records { get; set; }
        public List<MeetingViewModel> meetings { get; set; }
    }
}
