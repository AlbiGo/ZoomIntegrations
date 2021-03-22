using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.RequestDTO
{
    public class Recurrence
    {
        public string type { get; set; }
        public string repeat_interval { get; set; }
        public string weekly_days { get; set; }
        public string monthly_day { get; set; }
        public string monthly_week { get; set; }
        public string monthly_week_day { get; set; }
        public string end_times { get; set; }
        public string end_date_time { get; set; }
    }
}
