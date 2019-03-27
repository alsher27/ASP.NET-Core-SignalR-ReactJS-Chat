using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexChatRepo.Entities;
using AlexChatRepo.Repository;
using AlexChatServices.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using AlexChatRepo;

namespace AlexChatServices.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepository;
        private readonly IMapper _mapper;
        private readonly ChatContext _chatContext;
        public MessageService(IMessageRepo messageRepository, IMapper mapper, ChatContext chatContext)

        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _chatContext = chatContext;
           
        }
        public async Task<List<Message>> GetMessagesForChat(int id)
        {
            var messages = await _messageRepository.GetMessagesForChat(id); 
            return messages;
        }


        public async void SaveMessage(MessageViewModel message)
        {
           
            var mes = _mapper.Map<MessageViewModel, Message>(message);
            mes.UserId = _chatContext.Users.FirstOrDefault(u => u.UserName == message.FromUsername).Id;
            
            _messageRepository.SaveMessage(mes);
            
        }
    }
}
