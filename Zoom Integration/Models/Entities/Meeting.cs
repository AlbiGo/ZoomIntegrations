using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;

namespace Zoom_Integration.Models.Entities
{
    public class Meeting : CreatedMeetingDTO
    {
        public DateTime created_at { get; set; }
        public string host_id { get; set; }
        public int id { get; set; }
        public string join_url { get; set; }
        public string start_url { get; set; }
        public string status { get; set; }
        public string uuid { get; set; }
    }
}
