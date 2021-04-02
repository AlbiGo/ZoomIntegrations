using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.ResponseDTO
{
    public class UserPageInfoDTO
    {
        public int page_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
        public int total_records { get; set; }
        public List<User> users { get; set; }
    }
}
