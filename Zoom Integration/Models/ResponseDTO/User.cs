using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.ResponseDTO
{
    public class User
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int type { get; set; }
        public long pmi { get; set; }
        public string timezone { get; set; }
        public int verified { get; set; }
        public string dept { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_login_time { get; set; }
        public string last_client_version { get; set; }
        public string pic_url { get; set; }
        public List<string> im_group_ids { get; set; }
        public string status { get; set; }
    }
}
