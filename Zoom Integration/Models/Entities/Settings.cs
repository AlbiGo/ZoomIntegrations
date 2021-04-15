using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.Entities;

namespace Zoom_Integration.Models.RequestDTO
{
    public class Settings
    {
        public bool host_video { get; set; }
        public bool participant_video { get; set; }
        public bool cn_meeting { get; set; }
        public bool in_meeting { get; set; }
        public bool join_before_host { get; set; }
        public bool mute_upon_entry { get; set; }
        public bool watermark { get; set; }
        public bool use_pmi { get; set; }
        public int approval_type { get; set; }
        public int registration_type { get; set; }
        public string audio { get; set; }
        public string auto_recording { get; set; }
        public bool enforce_login { get; set; }
        public string enforce_login_domains { get; set; }
        public string alternative_hosts { get; set; }
        public List<GlobalDialInNumber> global_dial_in_countries { get; set; }
        public bool registrants_email_notification { get; set; }
    }
}
