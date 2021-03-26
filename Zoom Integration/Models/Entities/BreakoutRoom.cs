using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.Entities
{
public class BreakoutRoom
    {
        public bool enable { get; set; }
        public List<Room> rooms { get; set; }
        public bool host_video { get; set; }
        public bool in_meeting { get; set; }
        public bool join_before_host { get; set; }
        public bool mute_upon_entry { get; set; }
        public bool participant_video { get; set; }
        public bool registrants_confirmation_email { get; set; }
        public bool use_pmi { get; set; }
        public bool waiting_room { get; set; }
        public bool watermark { get; set; }
        public bool registrants_email_notification { get; set; }
    }
}