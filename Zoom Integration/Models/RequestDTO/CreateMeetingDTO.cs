using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.RequestDTO
{
    public class CreateMeetingDTO
    {
        public string topic { get; set; }
        public string type { get; set; }
        public string start_time { get; set; }
        public string duration { get; set; }
        public string schedule_for { get; set; }
        public string timezone { get; set; }
        public string password { get; set; }
        public string agenda { get; set; }
        public Recurrence recurrence { get; set; }
        public Settings settings { get; set; }
    }
}
