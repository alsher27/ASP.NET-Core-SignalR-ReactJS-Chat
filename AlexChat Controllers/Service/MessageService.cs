using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AlexChat.Models;
using AlexChat.Repository;
using AlexChat.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AlexChat.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _messageRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ChatContext _chatContext;
        public MessageService(IMessageRepo messageRepository, IMapper mapper, ChatContext chatContext, IHubContext<ChatHub> hubContext)

        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _chatContext = chatContext;
            _hubContext = hubContext;
        }
        public async Task<List<Message>> GetMessagesForChat(int id)
        {
            var messages = await _messageRepository.GetMessagesForChat(id); 
            return messages;
        }


        public async Task ProcessMessage(MessageViewModel message)
        {
           
            var mes = _mapper.Map<MessageViewModel, Message>(message);
            mes.UserId = _chatContext.Users.FirstOrDefault(u => u.UserName == message.FromUsername).Id;
            
            var users = await _messageRepository.ProcessMessage(mes);
            var targetUsers = users.Select(u => u.Id).ToList();

            IClientProxy clientProxy = _hubContext.Clients.Users(targetUsers);
            await clientProxy.SendAsync("Receive", message);
        }
    }
}
