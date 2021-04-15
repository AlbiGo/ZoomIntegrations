using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;

namespace Zoom_Integration.Models.Entities
{
    public class Meeting 
    {
        public string uuid { get; set; }
        public long id { get; set; }
        public string host_id { get; set; }
        public string host_email { get; set; }
        public string topic { get; set; }
        public int type { get; set; }
        public string status { get; set; }
        public string timezone { get; set; }
        public string agenda { get; set; }
        public DateTime created_at { get; set; }
        public string start_url { get; set; }
        public string join_url { get; set; }
        public string password { get; set; }
        public string h323_password { get; set; }
        public string pstn_password { get; set; }
        public string encrypted_password { get; set; }
        public SettingResDTO settings { get; set; }
    }
}
