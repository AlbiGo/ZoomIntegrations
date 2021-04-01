using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.RequestDTO
{
    public class updateUserDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string type { get; set; }
        public string pmi { get; set; }
        public string timezone { get; set; }
        public string dept { get; set; }
        public string vanity_name { get; set; }
        public string host_key { get; set; }
        public string cms_user_id { get; set; }
        public string job_title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string phone_number { get; set; }
        public string phone_country { get; set; }
    }
}
