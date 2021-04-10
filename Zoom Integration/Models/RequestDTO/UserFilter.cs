using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.RequestDTO
{
    public class UserFilter
    {
        public string status { get; set; }
        public string role_id { get; set; }
        public string include_fields { get; set; }
        public int? page_number { get; set; }
        public int? page_size { get; set; }
        public string next_page_token { get; set; }
    }
}
