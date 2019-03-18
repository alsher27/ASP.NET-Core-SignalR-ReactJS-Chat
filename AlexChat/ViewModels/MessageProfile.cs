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
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToString("u")))
                .ForMember(dest => dest.Chat, opt => opt.MapFrom(src => src.Chat.Id))
                .ReverseMap()
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.Parse(src.DateTime)))
                .ForPath(dest => dest.Chat.Id, opt => opt.MapFrom(src => src.Chat));
        }
    }
}
