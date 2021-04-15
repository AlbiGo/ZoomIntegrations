using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoom_Integration.Models.RequestDTO;
using Zoom_Integration.Models.ResponseDTO;
using Zoom_Integration.ViewModels;

namespace Zoom_Integration.AutoMapper.Profiles
{
    public class MeetingProfile : Profile
    {
       public MeetingProfile()
        {
            CreateMap<CreatedMeetingDTO, MeetingViewModel>()
                   .ForMember(dest =>
                       dest.hostEmail,
                       opt => opt.MapFrom(src => src.host_email))
                   .ForMember(dest =>
                       dest.topic,
                       opt => opt.MapFrom(src => src.topic))
                   .ForMember(dest =>
                       dest.agenda,
                       opt => opt.MapFrom(src => src.agenda))
                   .ForMember(dest =>
                       dest.contact_email,
                       opt => opt.MapFrom(src => src.settings.contact_email))
                   .ForMember(dest =>
                       dest.contact_name,
                       opt => opt.MapFrom(src => src.settings.contact_name))
                   .ForMember(dest =>
                       dest.startURL,
                       opt => opt.MapFrom(src => src.start_url))
                   .ForMember(dest =>
                       dest.join_url,
                       opt => opt.MapFrom(src => src.join_url))
                    .ForMember(dest =>
                       dest.password,
                       opt => opt.MapFrom(src => src.password));
        }

    }
}
