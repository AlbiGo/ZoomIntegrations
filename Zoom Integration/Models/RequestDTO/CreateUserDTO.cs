using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.Entities;

namespace Zoom_Integration.Models.RequestDTO
{
    public class CreateUserDTO
    {
        public string action { get; set; }
        public UserInfo user_info { get; set; }
    }
}
