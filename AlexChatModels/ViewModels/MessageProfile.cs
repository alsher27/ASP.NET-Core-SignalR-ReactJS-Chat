using AlexChatModels;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexChatModels.ViewModels
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>(MemberList.Destination)
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToString()))
                //.ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
                .ReverseMap()
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.Parse(src.DateTime)));
                //.ForPath(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId));
        }
    }
}
