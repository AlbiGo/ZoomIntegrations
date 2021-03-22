using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.ResponseDTO;

namespace Zoom_Integration.Interfaces
{
    public interface IUserService
    {
        public  Task<List<User>> getAllUsers(string s);
        public Task<UserInformationDTO> getcurrentUser(string apiToken);


    }
}
