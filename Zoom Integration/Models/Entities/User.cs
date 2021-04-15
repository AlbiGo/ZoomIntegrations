using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.Entities
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
        public string vanity_name { get; set; }
        public string host_key { get; set; }
        public string cms_user_id { get; set; }
        public string job_title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string phone_country { get; set; }
        public string dept { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_login_time { get; set; }
        public string last_client_version { get; set; }
        public string pic_url { get; set; }
        public List<string> im_group_ids { get; set; }
        public string status { get; set; }
        public string language { get; set; }
        public string phone_number { get; set; }
        public string role_id { get; set; }
    }
}
