using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.Interfaces
{
    public interface IUserService
    {
        public  Task<UserPageInfoDTO> getAllUsers(string s, UserFilter filter);
        public Task<UserViewModel> getcurrentUser(string apiToken);
        public Task<UserInformationDTO> getcurrentUserDetails(string apiToken);
        public Task<CreatedUserDTO> createUser(string apiToken, CreateUserDTO model);
        public Task deleteUser(string apiToken, string userID);
        public Task updateUser(string apiToken, updateUserDTO model, string userId);
        public Task<UserInformationDTO> getUser(string apikey, string id);




    }
}
