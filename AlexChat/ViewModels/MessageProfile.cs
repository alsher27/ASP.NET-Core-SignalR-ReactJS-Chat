using AlexChat.Models;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChat.ViewModels
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>(MemberList.Destination)
                .ForMember(dest => dest.dateTime, opt => opt.MapFrom(src => src.dateTime.ToString("u")))
                .ForMember(dest => dest.chat, opt => opt.MapFrom(src => src.chat.Id))
                .ReverseMap()
                .ForMember(dest => dest.dateTime, opt => opt.MapFrom(src => DateTime.Parse(src.dateTime)))
                .ForPath(dest => dest.chat.Id, opt => opt.MapFrom(src => src.chat))
                ;
        }
    }
}
