using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.RequestDTO
{
    public class Settings
    {
        public string host_video { get; set; }
        public string participant_video { get; set; }
        public string cn_meeting { get; set; }
        public string in_meeting { get; set; }
        public string join_before_host { get; set; }
        public string mute_upon_entry { get; set; }
        public string watermark { get; set; }
        public string use_pmi { get; set; }
        public string approval_type { get; set; }
        public string registration_type { get; set; }
        public string audio { get; set; }
        public string auto_recording { get; set; }
        public string enforce_login { get; set; }
        public string enforce_login_domains { get; set; }
        public string alternative_hosts { get; set; }
        public List<string> global_dial_in_countries { get; set; }
        public string registrants_email_notification { get; set; }
    }
}
