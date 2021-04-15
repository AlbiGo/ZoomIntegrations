using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.ViewModels
{
    public class MeetingViewModel
    {
        public string hostEmail { get; set; }
        public string topic { get; set; }
        public string agenda { get; set; }
        public string startURL { get; set; }
        public string join_url { get; set; }
        public string password { get; set; }
        public string contact_email { get; set; }
        public string contact_name { get; set; }
        public DateTime created_at { get; set; }
        public int? duration { get; set; }
        public string pmi { get; set; }
        public string timezone { get; set; }
        public int type { get; set; }
        public string id { get; set; }
        public string uuid { get; set; }


    }
}
