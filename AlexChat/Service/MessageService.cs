using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AlexChat.Models;
using AlexChat.Repository;
using AlexChat.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AlexChat.Service
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
        public async Task<List<MessageViewModel>> GetMessagesForChat(int id)
        {
            var messages = await _messageRepository.GetMessagesForChat(id); 
            var messagesViewModel = new List<MessageViewModel>();
            foreach (Message mes in messages)
            {
                var temp = _mapper.Map<Message, MessageViewModel>(mes);
                temp.FromUsername = mes.User.UserName;
                messagesViewModel.Add(temp);
            }
            return messagesViewModel;
        }


        public async Task<List<User>> ProcessMessage(MessageViewModel message)
        {
           
            var mes = _mapper.Map<MessageViewModel, Message>(message);
            mes.UserId = _chatContext.Users.FirstOrDefault(u => u.UserName == message.FromUsername).Id;
            
            return await _messageRepository.ProcessMessage(mes);
        }
        
        
    }
}
