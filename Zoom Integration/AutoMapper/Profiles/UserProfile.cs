using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                   .ForMember(dest =>
                       dest.first_name,
                       opt => opt.MapFrom(src => src.first_name))
                   .ForMember(dest =>
                       dest.last_name,
                       opt => opt.MapFrom(src => src.last_name))
                   .ForMember(dest =>
                       dest.email,
                       opt => opt.MapFrom(src => src.email));
        }
    }
}
